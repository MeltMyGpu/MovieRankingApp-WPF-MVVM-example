using System;
using System.Linq;
using DBTest.Context;
using DBTest.Models;


namespace Program
{
    public class Program
    {
        public static void Main()
        {
            using var Db = new CustomerDbContext();

            Db.Add(new CustomerModel { FirstName = "Kieran", LastName = "Burnett", Address = "CB89TT", PhoneNumber = 07500252300, EmailAddress = "test@test.com", Id=1});

            //Console.WriteLine(Db.Customers.Where(x => Db.Customers. == 1 );
            var Clients1 = Db.Customers.ToArray();
            foreach (var client in Clients1)
            {
                Console.WriteLine(client.FirstName);
            }
        }
    
    }


}
