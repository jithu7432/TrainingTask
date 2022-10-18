using System.ComponentModel;

namespace Processing
{
    public class Program
    {
        public static void Main() {

            var b = new BatteryUtils();
            var df2 = b.GetData(2);

            var res = b.ComputeDecrement(df2);

            foreach (var x in res) {
                Console.WriteLine(x);
            }

            Console.WriteLine();
            var df = b.GetData(1);
            var res2 = BatteryUtils.CalculateChargingBounds(df);

            var res3 = BatteryUtils.ClassifyCounts(df, res2);

            foreach (var x in res3) {
                Console.WriteLine(x);
            }
        }

    }


}
