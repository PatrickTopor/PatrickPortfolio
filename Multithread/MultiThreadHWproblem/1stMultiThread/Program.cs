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

            // create a data array we will put into our MyData class object
            int[] theData = new int[] { 1, 2, 3, 4, 5 };
            
            // instantiate an instance of the MyData class and call it myDataObject
            // its job is just to hold data.
            // add code here:
            
            
            bool othersNotDone = true;  // bool variable to use as gate while waiting for 2 other threads

            // define a new thread called t2 that uses the delegate method AddSomeNumbers
            // add code here:
            
            // define a new thread called t3 that uses the delegate method MultiplySomeNumbers
            // add code here:

            // start the t2 method, passing in your instance of the MyData class
            // add code here:
            
            // start the t3 method, passing in your instance of the MyData class
            // add code here:

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

            Console.ReadLine();  // just wait
        }

        private static void AddSomeNumbers(object inputObject) // threads can only accept a input parameter of type object
        {
            // start by defining a local MyData object variable, with any name 
            // set this new object equal to the object that was passed in with the thread start call
            // but cast it to be an object of the MyData class type
            // add code here:


            
            // now build a loop and total the value of the array values in the array, in that object
            // add code here:


            // then set the AddTotal property of the local MyData object to the total you just calculated
            // add code here:

            Console.WriteLine("Thread: 2 done.");
        }

        private static void MultiplySomeNumbers(object inputObject) // after you are in the method, you cast the input method to the type of object you passed in with when you started the thread
        {
            // again start by defining a local MyData object variable, with any name 
            // set this new object equal to the object that was passed in with the thread start call
            // but cast it to be an object of the MyData class type
            // add code here:


            
            // now build a loop and calculate the product of multiplying all the array values
            // add code here:

            // then set the MultiplyTotal property of the local MyData object to the total you just calculated
            // add code here:
            

            Console.WriteLine("Thread: 3 done.");
        }

        
    }
}
