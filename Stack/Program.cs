using System;
//using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack Data Structure");

            Stack<int> newStack = new Stack<int>();

            newStack.Push(55);
            newStack.Push(44);
            newStack.Push(555);
            newStack.Push(12);
            newStack.Push(1);

            //Console.WriteLine(newStack.Pop());

            //for (int i = 0; i < newStack.Count; i++)
            //{
            //    Console.WriteLine(newStack.Peek());
            //}

            //newStack.Clear();

            //int item = 555;
            //Console.WriteLine(newStack.Contains(item));

            //int[] arr = new int[10];
            //newStack.CopyTo(arr, 3);
            //arr = newStack.ToArray();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            //newStack.TrimExcess();

            //int result;
            //newStack.TryPop(out result);
            //Console.WriteLine(result);

            foreach (int item in newStack)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

    }
}
