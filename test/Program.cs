using System;
using Microsoft.Data.Analysis;

namespace ConsoleApp{
    public class Program{
        public static void Main(){
            Console.WriteLine("Hello, World!");
            var df = DataFrame.LoadCsv("../test.csv");
            Console.WriteLine(df);

        }
    }
}
