using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneAccount
{
    class RehberParametre
    {
        public string NameSurname;
        public string CompanyName;
        public string GSM;
        public string Phone;
        public string email;

        public static implicit operator char(RehberParametre v)
        {
            throw new NotImplementedException();
        }
    }
}
