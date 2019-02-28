using System;
namespace PatrickLinkedList
{
    public class LinkedListClass
    {
        public LinkedListClass()
        {
        }
    }
    public class IntLinkedList
    {
        protected class LinkedListNode
        {
            //Property holds "data"
            public int node_data; //Property holds reference pointer, which is next node in the list
            public LinkedListNode node_next_pointer;
            //Constructor: node_next_pointer property is set to null by default      
            public LinkedListNode(int value)
            {
                node_data = value;
            }
        } // end of nested class definition

        // the only data item the class has is the pointer(actually a node with a reference object in it) to the first item in the list 
        protected LinkedListNode frontOfList; 
        // No constructor, but an undefined object has the value null; which is our flag that the list is empty
        // Method to add a node to the front of the list:
        public void InsertAtFront(int value)
        {
            LinkedListNode newNode = new LinkedListNode(value);  
            // create new node   
            newNode.node_next_pointer = frontOfList; 
            // make this new first node point to what was previously the first node;
            // if the List had been empty, then we just made the newNode point to "null", which says there is no 2nd node.
                frontOfList = newNode; 
            // change the "reference" to front of list to point to this new one, which itself now points to the prior front of list
        }// we are dealing with this frontOfList because this method specifically says to add to the front.  Later we will insert into other places.
        public int RemoveFromFront()  
        // returns the "value" that the list object stores, in this case, an int
        {
            int returnVal; 
            if(frontOfList == null)
            {
            throw new IndexOutOfRangeException("list is empty");
            }
            else
            {
                returnVal = frontOfList.node_data; 
                // get the data from the node at the front of the list
                frontOfList = frontOfList.node_next_pointer;  
                // copy the front oflist's node's pointer to the next node, into the front of List
                // if there was not another node, we just copied a null into the pointer, which says the list is now empty
            }
            return returnVal;
        }
        public void Print()
		{
            // The four steps in the "Linked List Traversal" schema are:
            // 1.Setup
            // 2.Iteration Logic
            // 3.Work (that is done at each iteration)
            // 4.Teardown (anything that happens after the iteration)
            // a simple 'list traversal' schema, 
            // just start at top, grab one, use it, then use its pointer to change the current one to the next one.    
            LinkedListNode cur = frontOfList;     
            // 1.Setup
            while (cur != null)                   
                // 2.Iteration Logic    
            {
                Console.WriteLine(cur.node_data); 
                // 3.Work (done at each iteration)        
                cur = cur.node_next_pointer;      
                // 2.Iteration Logic    
            }
            // 4.Teardown (anything that happens after the iteration)
        }

        public bool Find(int target)
		{
			LinkedListNode cur = frontOfList;                         
            // 1.Setup
            while (cur != null) 
                //if list empty, or at end of list: done 2.Iteration Logic    
            {
                if (cur.node_data == target)                          
                    // 3.Work         
                {
                    return true;                                     
                    // 4. Tear down        
                }        
                cur = cur.node_next_pointer;                    
                // 2.Iteration Logic    
            }
            return false;                                           
            // 4. Tear down
        }
        public bool RemoveByValue(int target) // return true if found, false if not
        {
            LinkedListNode cur = frontOfList;

			// deal with condition if list is empty
			if (cur == null)
            {
                throw new Exception("Nothing is in the list");
            }
			// create a current “reference” variable
			// if value is found in the first entry, change the frontOfList contents to effectively remove that node, and return true, for success
			else if (cur.node_data == target)
            {
                RemoveFromFront();
                return true;
            }

            // else list was not empty, and the first item was not the one we wanted
            else
            {
				//already checked 1st one, need to look past current one to next one to see if that’s the one. As we need to
				//change the pointer on the node BEFORE the one we remove, so we want current to point to node just before it

				// do a while loop, where it exits if the current node’s pointer to the next node sees that the next node is null, which indicates we are at bottom of list
                while(cur.node_next_pointer != null)
                {
                    // in the while loop 

                    // if the current node’s pointer sees that the next node has the value we are looking for,
                    if (cur.node_next_pointer.node_data == target)
                    {
                        // re-wire the current node’s next pointer to point to the node AFTER the next node, which will 
                        cur.node_next_pointer = cur.node_next_pointer.node_next_pointer;
                        //leave it disconnected as an orphan.
                        return true;    
                        // get the data from the node at the front of the list

                        // and return true  (found it)
                    }

					// if not, move the pointer, current, to the next node 
					cur = cur.node_next_pointer;
					// the value might be null, which is ok, our while loop we detect we are done
				}
            }//end of else statement

            // if walked the entire list and did not find, will return false
            return false;

        }//end of method

		}//end of class
}
