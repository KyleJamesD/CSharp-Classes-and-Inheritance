using System;


namespace Lab2
{
    public class Wages : Employee
    {
        public double Hours { get; set; }
        public double Rate { get; set; }

        public Wages(string id, string name, string address, string phone, long sin, string dateOfBirth, string department, double hours, double rate) : base(id, name, address, phone, sin, dateOfBirth, department)

        {
            Hours = hours;
            Rate = rate;
        }

        public double GetPay()
        {
            double salary = 0;
            double overTime = 0;
            double overTimeSalary = 0;
            double regularHoursSalary = 0;
            // TODO: Implement the method to return the payment
            // ....................................
            if (Hours > 40) 
            {
                overTime = Hours - 40;
                overTimeSalary = Rate * overTime * 1.5;
                regularHoursSalary = 40 * Rate;
                salary = overTimeSalary + regularHoursSalary;
            }
            else
            {
                salary = Hours * Rate;

            }

            return salary;
        }
    }
}
