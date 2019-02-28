using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1stMultiThread
{
   
    class Program
    {
        static void Main(string[] args)
        {
            // we are in the first thread, which you started when you told VS to "start" (at class Program, method Main)
            Random myRandom = new Random();
            // create a data array we will put into our MyData class object
            int[] theData = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Here you need to instantiate an instance of the MyData class and call it myDataObject
            // its job is just to hold data, add code here:
            MyData myDataObject = new MyData(theData);

            bool othersNotDone = true;  // bool variable to use as gate while waiting for 2 other threads

            // add code here to define a new thread called t2 that uses the delegate method AddSomeNumbers
            Thread t2 = new Thread(AddSomeNumbers);

            // add code here to define a new thread called t3 that uses the delegate method MultiplySomeNumbers
            Thread t3 = new Thread(MultiplySomeNumbers);

            // add code here to start the t2 method, passing in your instance of the MyData class
            t2.Start(myDataObject);

            // add code here to start the t3 method, passing in your instance of the MyData class
            t3.Start(myDataObject);

            Console.WriteLine("Thread1: now waiting for other two threads");

            while (othersNotDone)  // thread 1 will wait here until other threads are done
            {
                othersNotDone = false;
                 Thread.Sleep(1000); // give CPU cycles back by sleeping for 1 seconds.
                 if (t2.IsAlive || t3.IsAlive)   // test if both threads are done yet?
                 {
                     othersNotDone = true;
                     Console.WriteLine("Thread 1 waiting!");
                 }
            }

            Console.WriteLine();
            Console.WriteLine("Thread 1: other 2 threads are now done");

            Console.WriteLine("Thread 1: now I can continue, assuming data I needed has been calculated");

            // use the data in the object that the other 2 threads have calucated and updated
            int answer = myDataObject.AddTotal + myDataObject.MultiplyTotal;

            Console.WriteLine("the sum of the added and the muliplied array is {0}", answer);

            // your answer should be 3628855

            Console.ReadLine();  // just wait
        }

        private static void AddSomeNumbers(object inputObject) // threads can only accept a input parameter of type object
        {
            // start by defining a local MyData object variable, with any name 
            // set this new object equal to the object that was passed in, but cast it to an object of type MyData
            // add your code here:
            MyData data1 = (MyData)inputObject;


            // now build a loop and total the value of the array values in the array, in that object
            // add your code here:
            int total = 0;
            for (int i = 0; i < 10; i++)
            {
                total = total + data1.TheDataArray[i];
            }

            // then set the AddTotal property of the local MyData object to the total you just calculated
            // add your code here:
           data1.AddTotal = total;

            Console.WriteLine("Thread: 2 done.");
        }

        private static void MultiplySomeNumbers(object inputObject) // after you are in the method, you cast the input method to the type of object you passed in with when you started the thread
        {
			// again start by defining a local MyData object variable, with any name 
			// set this new object equal to the object that was passed in, but cast it to an object of type MyData
			// add your code here:
			MyData data2 = (MyData)inputObject;


			// now build a loop and calculate the product of multiplying all the array values
			// add your code here:
			int total = 1;
			for (int i = 0; i < 10; i++)
			{
                total = total * data2.TheDataArray[i];
			}

            // then set the MultiplyTotal property of the local MyData object to the total you just calculated
            // add your code here:
            data2.MultiplyTotal = total;

            Console.WriteLine("Thread: 3 done.");
        }

        
    }
}
