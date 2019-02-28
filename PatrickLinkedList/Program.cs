using System;

namespace PatrickLinkedList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			IntLinkedList MyLinkedList = new IntLinkedList();

			MyLinkedList.InsertAtFront(101);

			MyLinkedList.InsertAtFront(102);

			MyLinkedList.InsertAtFront(103);

			MyLinkedList.InsertAtFront(104);

			MyLinkedList.InsertAtFront(105);

			Console.WriteLine("should be 105  " + MyLinkedList.RemoveByValue(105));

			Console.WriteLine("should be 101  " + MyLinkedList.RemoveByValue(101));

			Console.WriteLine("should be 103  " + MyLinkedList.RemoveByValue(103));

			MyLinkedList.Print();

			Console.ReadLine();


		}
    }
}
