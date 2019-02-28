using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260_Heap
{
        
        class Program  // Progam to exercise our Heap
        {
            public static void Main(String[] args)
            {
                
                Heap myHeap = new Heap(21);  // create a new heap, with a storing array of size 21

                myHeap.Insert(new Node(40, "A")); // build it by just doing inserts
                myHeap.Insert(new Node(70, "B")); // good if you are building this up from new data coming one at a time
                myHeap.Insert(new Node(20, "C"));  // but if have an existing array of data, there is a faster algorithm
                myHeap.Insert(new Node(60, "D"));
                myHeap.Insert(new Node(50, "E"));
                myHeap.Insert(new Node(100, "F"));
                myHeap.Insert(new Node(82, "G"));
                myHeap.Insert(new Node(35, "H"));
                myHeap.Insert(new Node(90, "I"));
                myHeap.Insert(new Node(10, "J"));
                myHeap.DisplayHeap();

                Console.WriteLine("Inserting a new node with value 120");  // test this
                myHeap.Insert(new Node(120, "K"));
                myHeap.DisplayHeap();

                Console.WriteLine("Inserting a new node ALSO with value 120");  // test this
                myHeap.Insert(new Node(120, "L"));
                myHeap.DisplayHeap();

                Console.WriteLine("Removing max element");   // test this
                myHeap.RemoveMaxNode();
                myHeap.DisplayHeap();

                Console.WriteLine("Changing root to 130");    // test this
                myHeap.HeapIncreaseDecreaseKey(1, 130);
                myHeap.DisplayHeap();

                Console.WriteLine("Changing root to 5");    // test this
                myHeap.HeapIncreaseDecreaseKey(1, 5);
                myHeap.DisplayHeap();


                Console.WriteLine("Changing 6th to 83");    // test this
                myHeap.HeapIncreaseDecreaseKey(6, 83);
                myHeap.DisplayHeap();
                Console.ReadLine();
            }
        }
    }

