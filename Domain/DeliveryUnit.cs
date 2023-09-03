using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Citymail1.Domain
{

    //En DeliveryUnit kan ta 1 paket åt gången
    abstract class DeliveryUnit
    {
        public DeliveryUnit(
            string id,
            string capacity,
            string reach
            )
        {
            Id = id;
            Capacity = capacity;
            Reach = reach;
        }
        
        public string Id { get; }

        public string capacity;
        public string Capacity 
        {
        get
            {
                return capacity;
            }
            set
            {
                Regex checkCapacity = new Regex("^[0-9]+$");
                if (!checkCapacity.IsMatch(value))
                {
                    throw new ArgumentException("Capacity input is invalid, only takes numeric value");
                }
                capacity = value;
            }
        }
        public string reach;
        public string Reach
        {
            get
            {
                return reach;
            }
            set
            {
                Regex checkReach = new Regex("^[0-9]+$");
                if (!checkReach.IsMatch(value))
                {
                    throw new ArgumentException("Reach input is invalid, only takes numeric value");
                }
                reach = value;
            }
        }

        public abstract void ViewDeliveryUnitDetails();
    }
}
