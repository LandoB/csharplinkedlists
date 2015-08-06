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
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
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
            if (this.First() == null)
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
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
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
    

