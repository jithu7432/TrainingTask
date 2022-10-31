using Microsoft.VisualBasic.Logging;
using System;
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

        public List<TimeSpan> Timeframe { get; set; }
        public string Lastupdated { get; set; }


        public DataProcessing() {

            var battery_adapter = new BatteryUtils();
            var charging_data = battery_adapter.GetChargingData();

            ComputeCharging(charging_data);
            ComputeDischarging(charging_data);

            Lastupdated = DateTime.Now.ToString();
            Timeframe = GetBoundsDate();

        }

        public void ComputeCharging(DataTable data_table) {
            int count = 0;
            foreach (DataRow row in data_table.Rows) {
                if (((int)row["Plugged"] == 1) && ((int)row["CurrentLevel"] >= 99)) {
                    count++;
                } else {
                    if (count > 1800) { BadCount++; } else if ((count > 0) && (count <= 1800)) { OptimalCount++; }
                    count = 0;
                }
            }
            if (count > 0) {
                if (count > 1800) { BadCount++; } else { OptimalCount++; }
            }
            count = 0;
            foreach (DataRow row in data_table.Rows) {
                if (((int)row["Plugged"] == 1) && ((int)row["CurrentLevel"] < 99)) {
                    count++;
                } else {
                    if (count > 0) { SpotCount++; }
                    count = 0;
                }
            }
            if (count > 0) { SpotCount++; }
        }

        public static List<TimeSpan> GetBoundsDate() {
            var now = DateTime.Now;
            var left_time = new TimeSpan(now.Hour, 0, 0);
            var right_time = new TimeSpan(now.Hour, 59, 59);
            var result = new List<TimeSpan> { left_time, right_time };
            return result;

        }


        public static long[] GetBoundsForTheHour() {
            long[] bounds = new long[2];
            var now = DateTime.Now;
            var left_date = now.Date + new TimeSpan(now.Hour, 0, 0);
            var right_date = now.Date + new TimeSpan(now.Hour, 59, 59);
            bounds[0] = new DateTimeOffset(left_date).ToUnixTimeSeconds();
            bounds[1] = new DateTimeOffset(right_date).ToUnixTimeSeconds();
            return bounds;

        }

        public void ComputeDischarging(DataTable data_table) {
            var bounds = GetBoundsForTheHour();

            DataRow previous = data_table.Rows[0];
            DataRow current;
            bool toggled = false;
            foreach (DataRow row in data_table.Rows) {

                if ((long)row["Timestamp"] < bounds[0]) {
                    previous = row;
                    continue;
                }
                current = row;
                if ((int)current["CurrentLevel"] < (int)previous["CurrentLevel"]) {
                    toggled = true;
                } else if ((int)current["CurrentLevel"] > (int)previous["CurrentLevel"]) {
                    toggled = false;
                }
                if (toggled) {
                    Drop += ((int)previous["CurrentLevel"] - (int)current["CurrentLevel"]);
                    Time++;
                }
                previous = current;

            }
        }




    }
}



