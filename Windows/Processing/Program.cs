namespace Processing
{
    public class Program
    {
        public static void Main() {

            var b = new BatteryUtils();
            var df = b.GetData();

            var res = b.ComputeDecrement(df);
            foreach(var x in res) {
                Console.WriteLine(x);
            }

            Console.WriteLine();
            var res2 = BatteryUtils.CalculateChargingBounds(df);
            var res3 = BatteryUtils.ClassifyCounts(df, res2);

            foreach(var x in res3) {
                Console.WriteLine(x);
            }
        }

    }


}
