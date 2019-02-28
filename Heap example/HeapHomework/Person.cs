using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapHomework
{
    public class Person
    {
        public int ReservationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public Person(int pReservationNumber, string pFirstName, string pLastName)
        {
            ReservationNumber = pReservationNumber;
            FirstName = pFirstName;
            LastName = pLastName;
        }
    }
}
