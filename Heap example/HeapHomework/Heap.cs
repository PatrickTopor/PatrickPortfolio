using HeapHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog260_Heap
{

    // from:  http://chinmaylokesh.wordpress.com/2012/02/16/c-binary-max-heap-implementation/

    public class Node  // our basic node object, _nodeValue used for maintaining the tree
    {
        public string nodeText { get; set; }  // for this example, our object will hold a single text string
        public int NodeValue { get; set; }

        public Node(int value, string pTextString)  //  constuctor
        {
            NodeValue = value;
            nodeText = pTextString;
        }
    }

    public class Heap
    {
        // Note, even though our storage array will start at 0, we will not use that location. 
        // So node indexes start at 1
        private Person [] heapArray;  // the storage that holds are heap
        public int maxSize;       // keep track of how big we are
        public int currentSize;   // keep track of how many entries we have

        public Heap(int creationSize)  // Constuctor, takes in the size user spec's for max size
        {
            maxSize = creationSize;  // set the maximum value
            currentSize = 0;         // set the heap to empty
            heapArray = new Person[maxSize + 1];  // instantiate the array, per the size 
            // (we are not going to use the zero element, as it makes the math statements simpler)
        }

        public bool IsEmpty  // property indicated empty heep
        {
            get
            {
                return currentSize == 0;  // will be true or false
            }
        }


        public bool Insert(Person newPerson)  // method to insert a new node, returns true if successful
        {
            if (currentSize == maxSize)  // fail if we are full  (could have an array expansion routine instead)
                return false;
           
            currentSize++; // bump up the count of entries
            heapArray[currentSize] = newPerson;  // add the new node at the very bottom
            CascadeUp(currentSize);  // check to see if we need to swap this up higher and higher
            return true;
        }

        //ask if this needed to be changed
        public Person RemoveMaxNode() // Remove maximum value node
        {
            //make this work
            Person root = heapArray[1];  // well, we have what we wanted!, but, we need to fix up the tree too
            heapArray[1] = heapArray[currentSize--]; // copy the very last node up to the root to delete the root AND decrease the total size
            CascadeDown(1);  // and then deal with the fact that the node we grabbed from the bottom probably doesn't belong on top
            return root;
        }

        public void CascadeUp(int index)
        {
            // general idea is: adding new one to very last spot, then check if its value is bigger than its parent.
            // If it is, swap them, and then, check the new higher spot for the same thing, and cascasde up until it is under
            // a node that is larger than it is.
            int parent = (index) / 2;  // simple way to always calc your parent loc in array
            //ask if this needed to be changed
            Person bottom = heapArray[index]; // create a new node object = to the one at the bottom
            //now walk up (by changing the pointer, index) until either you reach the top, or you find
            // a parent that is bigger than you are
            //how come some accept reservation number while others dont?
            while (index > 1 && heapArray[parent].ReservationNumber < bottom.ReservationNumber)
            {
                heapArray[index] = heapArray[parent]; //new node must be bigger than parent, so push the parent down one
                // at which point the parent and child are ==, and the child data is lost, but you have it when you saved bottom
                index = parent; // move the pointers up, and do it again
                parent = (parent) / 2;
            }
            heapArray[index] = bottom;  // finally either the node above you is bigger (or there are no more)
            // so you overwrite that parent (which you has just pushed a copy of down to your child before you got here
        }


        public void CascadeDown(int index)  // 
        {
            // we use this 2 ways.  
            // [1] if we just removed the top node, we copied a bottom node to the top, and we need to bubble it down
            // to its correct location.
            // [2] if we changed the value of a node anywhere in the tree, we tested if this nodes new value means it must cascade up,
            // or down.  If down, we would be calling this method.
            //
            // putting a new larger node in above other nodes, or changing a node's value such that it is now larger
            // than its children, so we deal with this ... 
            // so we have to fix that. Look at its left and right children, then move it down (swap it) with the LARGER of its 2 children.
            // Because you just picked the larger of the 2 children, you know the one you just swapped up one is safely larger than what used to be it’s peer
            // so the one swapped UP will be ok, as its larger than the unswapped child, and by definition, its larger than the child you just did the swap to.
            // Then you need to recurse, and see if the node that got pushed down is bigger than its new kids, etc. 
            // until either its “good” or there are no more children under it.


            int largerChild; // a semiphore, "note" to tell us which way to go down, left or right
            Person top = heapArray[index]; // as before, we make a copy of the node that we will eventually put somehwere
            while (index <= currentSize / 2)  // if we are not at the bottom, 
            {
                // get pointers to our 2 childen
                int leftChild = 2 * index;
                int rightChild = leftChild + 1;

                if (rightChild <= currentSize && heapArray[leftChild].ReservationNumber < heapArray[rightChild].ReservationNumber)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.ReservationNumber >= heapArray[largerChild].ReservationNumber) // what if we ARE bigger than both children?
                    break; // then get out of the loop, we found where we need to stay

                // if not, then we swap our bigger child up to be the new parent, and walk down to where the child was
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
                // and loop to do it all again
            }
            heapArray[index] = top; // as in cascade up, we overwrite the child with our saved top node, knowing
            // that we just pushed up a copy of the child to be our parent
        }

        public bool HeapIncreaseDecreaseKey(int index, int newValue)  // method lets you change a value of an existing node, based on its current index
        {
            if (index < 1 || index >= currentSize)  // reject nodes that don't exist
                return false;                             
            int oldValue = heapArray[index].ReservationNumber;     // change the value
            heapArray[index].ReservationNumber = newValue;
            if (oldValue < newValue)   // then call either cascade up or down, based on if we upped or decreased the value
                CascadeUp(index);
            else
                CascadeDown(index);
            return true;
        }

        
    }
}
