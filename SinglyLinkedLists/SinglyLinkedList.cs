using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode first_node;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            if (values.Count() == 0)
            {
                throw new ArgumentException();
            }
            for (var i = 0; i < values.Count(); i++)
            {
               this.AddLast(values[i].ToString());
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return this.ElementAt(i); }
            set
            {
                var placeHolderList = new SinglyLinkedList();
                for (var q = 0; q < this.Count(); q++)
                {
                    if (q == i)
                    {
                        placeHolderList.AddLast(value);
                    }
                    else
                    {
                        placeHolderList.AddLast(this.ElementAt(q));
                    }
                }
                first_node = new SinglyLinkedListNode(placeHolderList.First());
                for (var w = 1; w < placeHolderList.Count(); w++)
                {
                    this.AddLast(placeHolderList.ElementAt(w));
                }
            }
        }

        public void AddAfter(string existingValue, string newValue)
        {
            int testForValue = -1;
            //throw new NotImplementedException();
            for (var i = 0; i < this.Count(); i++)
            {
                if (this.ElementAt(i) == existingValue)
                {
                    testForValue = i;
                    break;
                }
            }
            if (testForValue < 0)
            {
                throw new ArgumentException();
            }
            var placeHolderList = new SinglyLinkedList();
            for (var q = 0; q < this.Count(); q++)
            {
                placeHolderList.AddLast(this.ElementAt(q));
                if (q == testForValue)
                {
                    placeHolderList.AddLast(newValue);
                }
            }
            first_node = new SinglyLinkedListNode(placeHolderList.First());
            for (var w = 1; w < placeHolderList.Count(); w++)
            {
                this.AddLast(placeHolderList.ElementAt(w));
            }
        }

        public void AddFirst(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            } 
            else
            {
                var newFirstNode = new SinglyLinkedListNode(value);
                var placeHolderList = new SinglyLinkedList();
                placeHolderList.AddFirst(newFirstNode.Value);
                for (var i = 0; i < this.Count(); i++)
                {
                    placeHolderList.AddLast(this.ElementAt(i));
                }
                first_node = new SinglyLinkedListNode(placeHolderList.First());
                for (var q = 1; q < placeHolderList.Count(); q++)
                {
                    this.AddLast(placeHolderList.ElementAt(q));
                }
                
            } 
        }

        public void AddLast(string value)
        {
            if (this.First() == null)
            {
                first_node = new SinglyLinkedListNode(value);
            }
            else
            {
                var node = this.first_node;
                while (!node.IsLast())
                {
                    node = node.Next;
                }
                node.Next = new SinglyLinkedListNode(value);
            }
            
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            // If the list is empty
            // this.Count() == 0;
            if (this.First() == null)
            {
                return 0;
            }
            else
            {
                int length = 1;
                var node = this.first_node;
                // Complexity is 0(n)
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }
                return length; 
            }
        }

        public string ElementAt(int index)
        {
            if (this.First() == null || this.Count() <= index)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var node = this.first_node;

                for(var i = 0; i <= index; i++)
                {
                    if ( i == index )
                    {
                        break;
                    }
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public string First()
        {
            if (this.first_node == null)
            {
                return null;
            }
            else
            {
                return this.first_node.Value;
            }

            // return this.first_node.Value

        }

        public int IndexOf(string value)
        {
            int testForValue = -1;
            //throw new NotImplementedException();
            for (var i = 0; i < this.Count(); i++)
            {
                if (this.ElementAt(i) == value)
                {
                    testForValue = i;
                    break;
                }
            }
            return testForValue;
        }

        public bool IsSorted() // Refactor to use CompareTo(Object obj) method since it will take anything not just a string.
        {
            if (this.First() != null)
            {
                for (var i = 0; i < this.Count()-1; i++)
                {
                    if (String.Compare(this.ElementAt(i), this.ElementAt(i + 1), StringComparison.CurrentCulture) == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            // If the list is empty
            var node = this.first_node;
            if (node == null)
            {
                // The list is empty.
                return null;
            } 
            else
            {
                // Step 1: Do I ned to loop???
                // Step 2: IF yes, Do I already have an example of how??? *** THIS IS VERY IMPORTANT ***
                // Step 3: How can I modify the previous examples???
                // Step 4: Write what I think works.
                // Step 5: Rebuild/Re-run tests.
                // Step 6: Rinse and repeat.

                while (!node.IsLast())
                {
                    node = node.Next;
                }
                return node.Value;
            }
        }

        public void Remove(string value)
        {
            int number = this.IndexOf(value);
            var placeHolderList = new SinglyLinkedList();
            for (var i = 0; i < this.Count(); i++)
            {
                if (i != number)
                {
                    placeHolderList.AddLast(this.ElementAt(i));
                }
            }
            first_node = new SinglyLinkedListNode(placeHolderList.First());
            for (var q = 1; q < placeHolderList.Count(); q++)
            {
                this.AddLast(placeHolderList.ElementAt(q));
            }           
        }

        public void Sort()
        {
            if (this.Count() < 2)
            {
                return;
            }
            else
            {
                while (!this.IsSorted())
                {
                    var node = first_node;
                    var node2 = node.Next;
                    for (var i = 1; i < this.Count(); i++)
                    {
                        if (node.Value.CompareTo(node.Next.Value) > 0)
                        {
                            var temp = node.Next.Value;
                            node2.Value = node.Value;
                            node.Value = temp;
                        }
                        node = node.Next;
                        node2 = node2.Next;
                    }
                }
            }
        }

        public string[] ToArray()
        {
            var node = this.first_node;
            string[] emptyArray = new string[] { };
            string[] myArray = new string[this.Count()];

            if (this.Count() == 0)
            {
                return emptyArray;
            } 
            else
            {
                for ( int i = 0; i < this.Count(); i++)
                {
                    myArray[i] = this.ElementAt(i);
                }
            } 
            return myArray; 
        }

        public override string ToString()
        {
            // THIS IS THE SOLUTION USING STRING BUILDER:
            var opening = "{";
            var ending = "}";
            var space = " ";
            //var output = "";
            var quote = "\"";
            var comma = "," + space;
            //output += opening;
            var node = this.first_node;
            StringBuilder builder = new StringBuilder();
            builder.Append(opening);
            if (this.Count() >= 1)
            {
                //output += space;
                builder.Append(space);
                while (!node.IsLast())
                {
                    //output += quote + node.Value + quote + comma;
                    builder.Append(quote).Append(node.Value).Append(quote).Append(comma);
                    node = node.Next;
                }
                //output += quote + this.Last() + quote;
                builder.Append(quote).Append(this.Last()).Append(quote);
            }
            //output += space;
            builder.Append(space);
            //output += ending;
            builder.Append(ending);
            //return output;
            return builder.ToString();

            /*
            // THIS IS TEACHER'S SOLUTION:
            var opening = "{";
            var ending = "}";
            var space = " ";
            var output = "";
            var quote = "\"";
            var comma = "," + space;
            output += opening;
            var node = this.first_node;
            if (this.Count() >= 1)
            {
                output += space;
                while (!node.IsLast())
                {
                    output += quote + node.Value + quote + comma;
                    node = node.Next;
                }
                output += quote + this.Last() + quote;
            }
            output += space;
            output += ending;
            return output;
            */

            /* THIS  WAS OUR SOLUTION:
            // If the list is empty
            var node = this.first_node;
            if (node == null)
            {
                // The list is empty.
                return "{ }";
            }
            else
            {
                // Check with Count() if the list has only one item:
                int length = 1;
                node = this.first_node;
                while (node.Next != null)
                {
                    length++;
                    node = node.Next;
                }
                return "{ \"foo\" }";
            */

        }

    }
}
    

