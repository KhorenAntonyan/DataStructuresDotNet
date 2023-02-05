using System;
using System.Text;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> ll = new LinkedList<int>();

            Console.WriteLine(ll.AddFirst(10).Value);
            Console.WriteLine(ll.AddFirst(11).Value);
            Console.WriteLine(ll.AddFirst(12).List.Count);

            LinkedListNode<int> node = new LinkedListNode<int>(13);
            ll.AddFirst(node);

            Console.WriteLine(ll.AddLast(9).Value);

            LinkedListNode<int> node2 = new LinkedListNode<int>(8);
            ll.AddLast(node2);

            //ll.Clear();

            //Console.WriteLine(ll.Contains(8));

            //int[] arr = new int[10];
            //ll.CopyTo(arr, 2);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            //Console.WriteLine(ll.Find(11).Next.Value);
            //Console.WriteLine(ll.FindLast(12).Next.Value);

            //ll.RemoveLast();

            LinkedListNode<int> node3 = new LinkedListNode<int>(7);

            Console.WriteLine(ll.AddAfter(node2, 7).Value);

            //Console.WriteLine(ll.AddBefore(node2, 7).Value);

            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            Console.WriteLine(sentence.Count);

            //foreach(int number in ll)
            //{
            //    Console.Write("{0} ", number);
            //}

            Console.ReadKey();
        }
    }
}
