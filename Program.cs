using System;

namespace CustomerStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[3] {
                new Customer("Nitika", "Chowdhary", new DateTime(1998, 12, 06)),
                new Customer("ABC", "XYZ", new DateTime(1988, 10, 08)),
                new Customer("MNO", "OQW", new DateTime(1987, 04, 16))
            };
            
            for (int i = 0; i < customers.Length; i++)
            {
                if (i == 0)
                {
                    customers[i].previous = null;
                    customers[i].next = customers[i + 1];
                }
                else if (i == (customers.Length - 1))
                {
                    customers[i].previous = customers[i - 1];
                    customers[i].next = null;
                }
                else
                {
                    customers[i].previous = customers[i - 1];
                    customers[i].next = customers[i + 1];
                }
            }
            Console.WriteLine("Traversing the doubly linked list from start:-\n");
            Customer head = customers[0];
            while (head != null)
            {
                Console.WriteLine($"{head.firstName} {head.lastName} is {head.customerAge()} years old");
                head = head.next;
            }
            Console.WriteLine("\n\nTraversing the doubly linked list from end:-\n");
            Customer tail = customers[customers.Length-1];
            while (tail != null)
            {
                Console.WriteLine($"{tail.firstName} {tail.lastName} is {tail.customerAge()} years old");
                tail = tail.previous;
            }

        }

        
    }
    class Customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }
        public Customer previous { get; set; }
        public Customer next { get; set; }

        public Customer(string firstName, string lastName, DateTime DOB)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.DOB = DOB;
        }
        
        public int customerAge()
        {
            DateTime dob = this.DOB;
            DateTime currentDate = DateTime.Now;
            return (currentDate - dob).Days/365;      
        }
    }
}
