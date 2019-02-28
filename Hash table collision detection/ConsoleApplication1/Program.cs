using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // make up 20 possible strings to store in hash table, using an empty [0] location for convenience, so array has 21 spots
            // will use loc's 1 thru 20 in our code below
            string[] dataArray = new string[] {"empty by design", "President", "Vice President", "Speaker of the House", "President pro tempore of the Senate",
                "Secretary of State", "Secretary of the Treasury", "Secretary of Defense", "Attorney General",
                "Secretary of the Interior", "Secretary of Agriculture", "Secretary of Commerce", "Secretary of Labor", "Secretary of Health and Human Services",
            "Secretary of Housing and Urban Development", "Secretary of Transportation", "Secretary of Energy", "Secretary of Education",
            "Secretary of Veterans Affairs", "Secretary of Homeland Security", "Prog 260 Teacher"};

            // instantiate our hash table instance
            OurHashTable theHashTable = new OurHashTable(15); // hash TABLE is size 15

            int howMany = 14;  // we will try and fit 14 entries into this table of size 15

            string value;  // the string value to store using the human readable key 
            
            int numcollisions = 0;

            Random myRandom = new Random();

            bool success = false; // did the insert into hash table succeed?

            // loop where we strore each string from the array using a human key from 1 to 14
            for (int loopPointer = 0; loopPointer < howMany; loopPointer++)  // insert each  into the hash table
            {
                value = dataArray[loopPointer + 1];  // get our string from out dataArray
                success = theHashTable.AddItem(loopPointer + 1, value);  // our human key is just the loopcounter +1
                if (!success)
                {
                    numcollisions++;  // count the collision occurance
                }

            }

            // ok, done storing data into the hash table, write out its contents
            //theHashTable.PrintState();

            Console.WriteLine();
            Console.WriteLine("We lost {0} pieces of data", numcollisions);
            Console.WriteLine();

            // ok, lets try and retrieve the data
            Console.WriteLine();
            Console.WriteLine("now we will see what our hashtable returns based on the keys we used to enter data");
            Console.WriteLine("for every collision we had storing the data, we get erroneous data returned");
            Console.WriteLine("find the duplicate values returned.");
            Console.WriteLine();
            for (int i = 1; i <= howMany; i++)
            {
                Console.WriteLine("if enter key of {0} we get back: {1}", i, theHashTable.GetItem(i));
            }

            Console.ReadLine();
        }

    }
}
