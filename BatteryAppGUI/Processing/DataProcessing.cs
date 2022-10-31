using System.Data;

namespace BatteryAppGUI
{
    public class DataProcessing
    {
        public int OptimalCount { get; set; }
        public int BadCount { get; set; }
        public int SpotCount { get; set; }

        public int Drop { get; set; }
        public int Time { get; set; }


        public DataProcessing() {

            var battery_adapter = new BatteryUtils();
            var charging_data = battery_adapter.GetChargingData();
            ComputeCharging(charging_data);
            ComputeDischarging(charging_data);
            //var discharging_data = battery_adapter.GetDischargeData();


            //var res1 = BatteryUtils.ComputeDischarging(discharging_data);
            //var res2 = BatteryUtils.CalculateChargingBounds(charging_data);
            //var res3 = BatteryUtils.ClassifyCounts(charging_data, res2);

            //_drop = $"{res1["Drop"]}";
            //_time = (double)res1["Time"];

            //_optimalCount = res3["OptimalCount"];
            //_badCount = res3["BadCount"];
            //_spotCount = res3["SpotCount"];

        }

        public void ComputeCharging(DataTable data_table) {
            foreach (DataRow dataRow in data_table.Rows) {
                Console.Write(dataRow["TimeStamp"] + " ");
                Console.Write(dataRow["CurrentLevel"] + " ");
                Console.Write(dataRow["Plugged"]);
                Console.WriteLine();
            }
        }

        public void ComputeDischarging(DataTable data_table) {
            foreach (DataRow dataRow in data_table.Rows) {
                Console.Write(dataRow["TimeStamp"] + " ");
                Console.Write(dataRow["CurrentLevel"] + " ");
                Console.Write(dataRow["Plugged"]);
                Console.WriteLine();

            }
        }
    }


}
