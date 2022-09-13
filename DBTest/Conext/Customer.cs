using System;
using System.Collections.Generic;

namespace DBTest.Conext
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string AddressLineOne { get; set; } = null!;
        public string PostCode { get; set; } = null!;
    }
}
