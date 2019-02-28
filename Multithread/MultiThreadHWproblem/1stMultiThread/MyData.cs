using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stMultiThread
{
    public class MyData  // objects from this class are used just to transport data among programs
    {
        public int[] TheDataArray { get; set; }  // internal array used for calculations, it will be passed in by a method call.

        public int AddTotal { get; set; }    // int property called AddTotal, will hold the total of all values in array

        public int MultiplyTotal { get; set; }  // int property called MultiplyTotal, will hold the value of multiply all elements of the array

        public MyData (int[] passedInArray)  // Constructor passes in the array to work with
        {
            TheDataArray = passedInArray;
        }
    }
}
