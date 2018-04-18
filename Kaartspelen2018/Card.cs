using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaartspelen2018
{
    public sealed class Card
    {
        public Card(String givenName, String givenAddress, int givenValue)
        {
            Name = givenName;
            Address = givenAddress;
            Value = givenValue;
        }





        public int Value { get; set; }

        public String Address { get; set; }

        public String Name { get; set; }

    }
}
