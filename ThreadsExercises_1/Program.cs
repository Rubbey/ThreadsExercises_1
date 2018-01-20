using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsExercises_1
{
    class Program
    {
        static void Main(string[] args)
        {            
            Thread thr_1 = new Thread(GetElement);
            thr_1.Name = "Watek 1";
            Thread thr_2 = new Thread(GetElement);
            thr_2.Name = "Watek 2";

            thr_1.Start();                
            thr_2.Start();       


            Console.WriteLine("\nProgram zakonczyl dzialanie!");
            Console.ReadLine();
        }

        public static void GetElement()
        {
            while (!ContainerOfInt.Instance.isEmpty)
            {                
                Console.WriteLine("{0} pobrał wartość [{1}]!",
                                    Thread.CurrentThread.Name,
                                    ContainerOfInt.Instance.getTheLastNumber());
                Random rndTime = new Random();
                Thread.Sleep(rndTime.Next(10));                                 
            }
        }
    }
}
