using System;

namespace Lab2
{
    public class PartTime : Employee
    {

        public double Hours { get; set; }
        public double Rate { get; set; }

        // TODO: Create the constructor and initialize the fields
        // ....................................

        public PartTime (string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double hours, double rate) : base(id, name, address, phone, sin, dateOfBirth, department)
        {
            Hours = hours;
            Rate = rate;
        }


        public double GetPay()
        {
            double salary = 0;
            // TODO: Implement the method to return the payment
            // ....................................
            salary = Hours * Rate;

            return salary;
        }
    }
}
