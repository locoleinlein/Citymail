using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace Citymail1.Domain
{
    class Car : DeliveryUnit
    {
        public Car(
            string id,
            string capacity,
            string reach,
            string registrationNumber)
            : base(id, capacity, reach)
        {
            RegistrationNumber = registrationNumber;
        }

        public string registrationNumber;

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                Regex checkRegistrationNumber = new Regex(@"^[A-Za-z]{3}[0-9]{2}[A-Za-z0-9]{1}");
                if (!checkRegistrationNumber.IsMatch(value))
                {
                    throw new ArgumentException("Registration number is invalid");
                }
                registrationNumber = value;
            }
        }
        public override void ViewDeliveryUnitDetails()
        {
            SetCursorPosition(4, 1);
            WriteLine($@"ID:                      {Id.ToUpper()}");

            SetCursorPosition(4, 3);
            WriteLine($@"Capacity (kg):           {Capacity.ToUpper()}");

            SetCursorPosition(4, 5);
            WriteLine($@"Reach (km):              {Reach.ToUpper()}");

            SetCursorPosition(4, 7);
            WriteLine($@"Registration number:     {RegistrationNumber.ToUpper()}");
        }



}
}
