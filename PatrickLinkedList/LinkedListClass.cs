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
            public LinkedListNode(int value)
            {
                node_data = value;
            }
        } 

        protected LinkedListNode frontOfList; 
        public void InsertAtFront(int value)
        {
            LinkedListNode newNode = new LinkedListNode(value);  
            // create new node   
            newNode.node_next_pointer = frontOfList; 

                frontOfList = newNode; 
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
            }
            return returnVal;
        }
        public void Print()
		{
           
            LinkedListNode cur = frontOfList;     
            while (cur != null)                       
            {
                Console.WriteLine(cur.node_data);       
                cur = cur.node_next_pointer;         
            }
        }

        public bool Find(int target)
		{
			LinkedListNode cur = frontOfList;                         
            while (cur != null) 
                //if list empty, or at end of list: done 
            {
                if (cur.node_data == target)                                  
                {
                    return true;                                           
                }        
                cur = cur.node_next_pointer;                      
            }
            return false;                                           
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
	
			else if (cur.node_data == target)
            {
                RemoveFromFront();
                return true;
            }

            // else list was not empty, and the first item was not the one we wanted
            else
            {		
                while(cur.node_next_pointer != null)
                {
                    if (cur.node_next_pointer.node_data == target)
                    {
                        
                        cur.node_next_pointer = cur.node_next_pointer.node_next_pointer;
                        return true;    
                        // get the data from the node at the front of the list and return true  (found it)
                    }

					// if not, move the pointer, current, to the next node 
					cur = cur.node_next_pointer;
					
				}
            }

            // if walked the entire list and did not find, will return false
            return false;

        	}

	}
}
