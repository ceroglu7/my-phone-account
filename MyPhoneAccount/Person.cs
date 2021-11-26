using System;

namespace MyPhoneAccount
{
    public class PersonDto
    {
        public class Person
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Fullname { get; set; }
            public string CompanyName { get; set; }
            public string GSM { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
    }
}
