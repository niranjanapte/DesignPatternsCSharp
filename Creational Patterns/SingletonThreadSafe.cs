/* Single with Thread Safe */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SingleTonPattern
{

    sealed class SingleTon
    {
        private static SingleTon single = new SingleTon();

        public static SingleTon Instance 
        {
            get { return single; } 
        }

        private SingleTon(){ }

        public void PrintMe()
        {
            Console.WriteLine("Singleton Class Testing");
        }
    }
    
    
    public class Program
    {
        public static void Main(string[] args)
        {
             SingleTon.Instance.PrintMe();
        }
    }
}
