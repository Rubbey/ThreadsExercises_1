using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsExercises_1
{
    public sealed class ContainerOfInt
    {
        private static ContainerOfInt o_instance = null;
        private List<int> o_listOfInts;
        public bool isEmpty { get; private set; } = false;
        private static Object singletonlock = new object();
        public static ContainerOfInt Instance
        {
            get
            {
                lock (singletonlock)
                {
                    if (o_instance == null)
                    {
                        o_instance = new ContainerOfInt();
                        o_instance.FillList();
                    }

                    return o_instance;
                }                
            }
        }

        private ContainerOfInt()
        {
            o_listOfInts = new List<int>();
        }

        private void FillList()
        {
            Random randomInt = new Random();
            for (int i = 0; i < 100; i++)
            {
                o_instance.o_listOfInts.Add(randomInt.Next(int.MaxValue));
            }
            Console.WriteLine("Nowa lista zostala zainicjalizowana i wypełniona!");
        }

        public int getTheLastNumber()
        {   
            lock (singletonlock)
            {
                int tempNumber = o_listOfInts.Last();
                o_listOfInts.RemoveAt(o_listOfInts.Count - 1);
                if (o_listOfInts.Count == 0) isEmpty = true;

                return tempNumber;
            }            
        }        
    }
}
