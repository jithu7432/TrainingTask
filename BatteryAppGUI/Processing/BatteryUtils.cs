using System.Data;
using System.Data.SQLite;

namespace BatteryAppGUI;

public class BatteryUtils
{

    //private readonly string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Battery;Integrated Security=True";
    private readonly string SQL_Discharging = "SELECT * FROM Daemon ORDER BY [TimeStamp]";
    private readonly string DatabasePath = "../BatteryDaemon.sqlite";

    public SQLiteConnection _connection;

    public BatteryUtils() {
        _connection = new($"Data Source={DatabasePath};Version=3;", true);
    }

    public DataTable GetChargingData() {
        SQLiteDataAdapter sql_adapter = new(SQL_Discharging, _connection);
        DataTable data_table = new();
        try {
            _connection.Open();
            sql_adapter.Fill(data_table);
        } catch (Exception e) {
            throw new Exception(e.Message);
        } finally {
            _connection.Close();
        }

        return data_table;

    }

    //public DataTable GetDischargeData() {
    //    SQLiteDataAdapter sql_adapter = new(SQL_Discharging, _connection);
    //    DataTable data_table = new();

    //    try {
    //        _connection.Open();
    //        sql_adapter.Fill(data_table);
    //    } catch (Exception e) {
    //        throw new Exception(e.Message);
    //    } finally {
    //        _connection.Close();
    //    }

    //    return data_table;
    //}
}

//List<long> time = new();
//List<long> status = new();
//List<long> cap = new();

//foreach (DataRow dataRow in data_table.Rows) {
//    var dd = dataRow.ItemArray;
//    time.Add((long)dd[0]);
//    status.Add((int)dd[1] - 1);
//    cap.Add((int)dd[2]);
//}
//Dictionary<string, List<long>> cout = new() {
//    ["TimeStamp"] = time,
//    ["CurrentLevel"] = cap,
//    ["BatteryStatus"] = status,
//};
//Dictionary<string, List<long>> dischargeData = new() {
//    ["TimeStamp"] = Enumerable.Reverse(time).ToList(),
//    ["CurrentLevel"] = Enumerable.Reverse(cap).ToList(),
//    ["BatteryStatus"] = Enumerable.Reverse(status).ToList(),
//};
//return dischargeData;
//}

//public static Dictionary<string, long> ComputeDischarging(DataTable data_table) {
//long ns = df["CurrentLevel"].Count;
//var level = df["CurrentLevel"];
//var time = df["TimeStamp"];
//var cout = new List<long[]>();

//int i = 1;
//while (i < ns) {
//    if (level[i - 1] > level[i]) {
//        long[] temp = { level[i], time[i] };
//        cout.Add(temp);
//    } else if (level[i - 1] < level[i]) {
//        long[] temp = { level[i], time[i] };
//        cout.Add(temp);
//    }
//    i++;
//}
//int nt = cout.Count;
//int drop = 0;
//long times = 0;
//int j = 1;
//while (j < nt) {
//    long[] curr = cout[j];
//    long[] prev = cout[j - 1];
//    if (prev[0] > curr[0]) {
//        drop += (int)(prev[0] - curr[0]);
//        var _diff = (curr[1] - prev[1]);
//        if (_diff < 3600) {
//            times += _diff;
//        }
//    }
//    j++;
//}
//Dictionary<string, long> res = new() {
//    ["Drop"] = drop,
//    ["Time"] = times,
//};
//return res;

//}

//public static List<Dictionary<string, long>> CalculateChargingBounds(Dictionary<string, List<long>> df) {
//    var plugged = df["BatteryStatus"];
//    var timestamp = df["TimeStamp"];

//int i = 0;
//int count = 0;
//int ns = plugged.Count;
//bool Toggled = false;
//long r = 0;
//long l = 0;
//var cout = new List<Dictionary<string, long>>();
//while (i < ns) {
//    if ((!Toggled) && (plugged[i] == 1)) {
//        Toggled = true;
//        l = timestamp[i];
//    }
//    if ((Toggled) && (plugged[i] == 1)) {
//        count++;
//    } else if ((Toggled) && ((plugged[i] != 1) || (i + 1 == ns))) {
//        r = timestamp[i - 1];
//        if (count > 0) {
//            var dat = new Dictionary<string, long> {
//                ["start"] = l,
//                ["end"] = r
//            };
//            cout.Add(dat);
//            r = 0;
//            l = 0;
//            Toggled = false;
//        }
//    }
//    i++;
//}
//return cout;

//}

//public static Dictionary<string, int> ClassifyCounts(Dictionary<string, List<long>> df, List<Dictionary<string, long>> bounds) {
//    var cout = new Dictionary<string, int> {
//        ["BadCount"] = 0,
//        ["OptimalCount"] = 0,
//        ["SpotCount"] = 0
//    };

//    var _timestamp = df["TimeStamp"];
//    var _levels = df["CurrentLevel"];
//    foreach (var x in bounds) {
//        bool toggled = false;
//        int l = 0;
//        int r = 0;
//        int index = 0;
//        foreach (var t in _timestamp) {
//            if ((!toggled) && (t >= x["start"])) {
//                toggled = true;
//                l = index;
//            }
//            if ((toggled) && (t >= x["end"])) {
//                r = index;
//                break;
//            }
//            index++;
//        }
//        var timestamp = _timestamp.Skip(l).Take(r - l + 1).ToList();
//        var levels = _levels.Skip(l).Take(r - l + 1).ToList();
//        int ns = timestamp.Count;
//        if (levels.Max() < 100) {
//            cout["SpotCount"]++;
//        } else {
//            int g = 0;
//            int c = 0;
//            int i = 0;
//            while (i < ns) {
//                if ((levels[i] == 100)) {
//                    c++;
//                } else {
//                    if (c > g) {
//                        g = c;
//                    }
//                    c = 0;
//                }
//                i++;
//                if ((i + 1) == ns) {
//                    if (c > g) {
//                        g = c;
//                    }
//                }
//            }
//            if (g > 1800) { // 1800 = 30 mins * 60 secs/min
//                cout["BadCount"]++;
//            } else {
//                cout["OptimalCount"]++;
//            }
//        }
//    }
//    return cout;

//}

//public static List<Dictionary<string, long>> GetChargingData(Dictionary<string, List<long>> df) {

//    var bounds = CalculateChargingBounds(df);
//    if (bounds == null) {
//        return ClassifyCounts(df, bounds);
//    }
//    return null;
//}

//}
