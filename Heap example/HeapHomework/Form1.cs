using Prog260_Heap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapHomework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Heap myHeap;
        Person person;

        private void Form1_Load(object sender, EventArgs e)
        {
            myHeap = new Heap(20);
        }

        private void buttonAddReser_Click(object sender, EventArgs e)
        {
            //add reservation
            int resNum = Convert.ToInt32(ResNum.Text);
            string fName = ResFirst.Text;
            string lName = ResLast.Text;
            person = new Person(resNum, fName, lName);
            myHeap.Insert(person);

            //clear textboxes
            ResNum.Clear();
            ResFirst.Clear();
            ResLast.Clear();

        }

        private void buttonGetReser_Click(object sender, EventArgs e)
        {
            //inform user heap is empty
            if (myHeap.IsEmpty)
            {
                textbox1.Text = "No more reservations here";
                textbox2.Clear();
                textbox3.Clear();
            }

            //tell user the highest priority customer
            else
            {
                person = myHeap.RemoveMaxNode();

                textbox1.Text = Convert.ToString(person.ReservationNumber);
                textbox2.Text = person.FirstName;
                textbox3.Text = person.LastName;
            }

        }

    }
}
