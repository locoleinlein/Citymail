using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static System.Console;

namespace Citymail1.Domain
{
   class Package
    {

        public Package(string sender, string destination, int packageId, string status)
        {
            Sender = sender;
            Destination = destination;
            PackageId = packageId;
            Status = status;
            
        }
        public string Sender { get; }
        public string Destination { get; }
        public int PackageId { get; }
        public string Status { get; set; }
        



   




    }

   
}
