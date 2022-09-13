using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTest.Conext;
using DBTest.Models;

namespace DBTest
{
    public class Testing
    {
        private readonly DbTestDatabaseContext DB = new DbTestDatabaseContext();
        public void CreateTest()
        {
            DB.Customers.Add(new Conext.Customer
            {
                FirstName = "kieran",
                LastName = "burnett",
                Email = "Test@Testing.com",
                PhoneNumber = "07500252300",
                AddressLineOne = "19 coopers close",
                PostCode = "CB89TT"
            });
            DB.SaveChanges();
        }

        public void ReadTest()
        {
            var customers = DB.Customers.ToArray();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}, \n {customer.FirstName},\n {customer.LastName} \n {customer.Email} \n {customer.PhoneNumber} \n {customer.AddressLineOne} \n {customer.PostCode}");
            }
        }
    }
}
