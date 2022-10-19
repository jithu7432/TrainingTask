using BatteryAppGUI;

namespace Processing
{
    public class Processed
    {
        public int _optimalCount { get; set; }
        public int _badCount { get; set; }
        public int _spotCount { get; set; }

        public string _drop { get; set; }
        public double _time { get; set; }


        public Processed() {

            var b = new BatteryUtils();
            var df1 = b.GetData(1);
            var df2 = b.GetData(2);

            var res1 = BatteryUtils.ComputeDecrement(df2);
            var res2 = BatteryUtils.CalculateChargingBounds(df1);
            var res3 = BatteryUtils.ClassifyCounts(df1, res2);

            _drop = $"{res1["Drop"]}";
            _time = (double)res1["Time"];

            _optimalCount = res3["OptimalCount"];
            _badCount = res3["BadCount"];
            _spotCount = res3["SpotCount"];

        }

    }


}
