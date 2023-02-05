using System;
//using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue Data Structure");

            Queue<int> newQueue = new Queue<int>();
            //Queue<int> newQueue1 = new Queue<int>();

            newQueue.Enqueue(10);
            newQueue.Enqueue(15);
            newQueue.Enqueue(2);
            newQueue.Enqueue(1);
            newQueue.Enqueue(7);

            //newQueue.Enqueue(10);
            //newQueue.Enqueue(15);
            //newQueue.Enqueue(2);
            //newQueue.Enqueue(1);
            //newQueue.Enqueue(7);

            //newQueue.Enqueue(10);
            //newQueue.Enqueue(15);
            //newQueue.Enqueue(2);
            //newQueue.Enqueue(1);
            //newQueue.Enqueue(7);

            //newQueue1.Enqueue(10);
            //newQueue1.Enqueue(15);
            //newQueue1.Enqueue(2);
            //newQueue1.Enqueue(1);
            //newQueue1.Enqueue(7);

            //Console.WriteLine(newQueue.Dequeue());
            //Console.WriteLine(newQueue.Dequeue());
            //Console.WriteLine(newQueue.Dequeue());
            //Console.WriteLine(newQueue.Dequeue());
            //Console.WriteLine(newQueue.Dequeue());

            //Console.WriteLine(newQueue1.Dequeue());
            //Console.WriteLine(newQueue1.Dequeue());
            //Console.WriteLine(newQueue1.Dequeue());
            //Console.WriteLine(newQueue1.Dequeue());
            //Console.WriteLine(newQueue1.Dequeue());

            Queue<string> stringQueue = new Queue<string>();

            stringQueue.Enqueue("Hi");
            stringQueue.Enqueue("i");
            stringQueue.Enqueue("am");
            stringQueue.Enqueue(".Net");
            stringQueue.Enqueue("Developer");

            Console.WriteLine(stringQueue.Dequeue());

            //foreach (string alpha in stringQueue)
            //{
            //    Console.WriteLine(alpha);
            //}

            //stringQueue.Clear();

            //Console.WriteLine(stringQueue.Contains(".Net")); 

            //int[] arr = new int[10];
            //newQueue.CopyTo(arr, 3);

            //int[] arr = newQueue.ToArray();

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            //newQueue.TrimExcess();

            //int result;
            //newQueue.TryPeek(out result);
            //Console.WriteLine(result);

            //for (int i = 0; i < stringQueue.Count; i++)
            //{
            //    Console.WriteLine(stringQueue.Peek());
            //}

            foreach (int item in newQueue)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
