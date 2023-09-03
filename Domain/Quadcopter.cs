using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Citymail1.Domain
{
    class Quadcopter : DeliveryUnit
    {
        public Quadcopter(
            string id,
            string capacity,
            string reach,
            string transponderId)
            : base (id, capacity, reach)
        {
            TransponderId = transponderId;
        }

        public string TransponderId { get; }

        public override void ViewDeliveryUnitDetails()
        {
            SetCursorPosition(4, 1);
            WriteLine($@"ID:                      {Id.ToUpper()}");

            SetCursorPosition(4, 3);
            WriteLine($@"Capacity (kg):           {Capacity.ToUpper()}");

            SetCursorPosition(4, 5);
            WriteLine($@"Reach (km):              {Reach.ToUpper()}");

            SetCursorPosition(4, 7);
            WriteLine($@"Transponder ID:          {TransponderId.ToUpper()}");
        }
    }

    
}
