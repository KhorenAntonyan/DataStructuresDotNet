using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> newList = new List<int>();

            newList.Add(10);
            newList.Add(25);
            newList.Add(3);
            newList.Add(2);
            newList.Add(45);


            //int[] arr = new int[10];
            //newList.CopyTo(arr, 3);

            //newList.GetRange(2, 3);
            //Console.WriteLine(newList.IndexOf(6776786));
            //Console.WriteLine(newList.IndexOf(3, 2));
            //Console.WriteLine(newList.IndexOf(3, 0, 3));
            //Console.WriteLine(newList[2]);
            //Console.WriteLine(newList[4]);
            //newList.Insert(5, 1);
            //Console.WriteLine(newList[4]);

            //Console.WriteLine(newList.LastIndexOf(25, 4, 4));

            //Console.WriteLine(newList[3]);
            //Console.WriteLine(newList.Remove(2));
            //Console.WriteLine(newList[3]);

            //Console.WriteLine(newList[2]);
            //newList.RemoveRange(2, 2);
            //Console.WriteLine(newList[2]);

            //newList.Reverse();
            //newList.Reverse(2, 3);

            //int[] arr = new int[10];

            //arr = newList.ToArray();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            foreach (int item in newList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

}

