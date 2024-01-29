using System;


namespace Lab2
{
    public class Employee
    {
        public string Id {get; set;}
        public string Name { get; set;}
        // TODO: Declare the rest of the fields
        // ....................................
        public string Address { get; set;}
        public string Phone { get; set;}
        public long Sin { get; set;}
        public string DateOfBirth { get; set;}
        public string Department { get; set;}

        public Employee(string id, string name, string address, string phone, long sin, string dateOfBirth, string department)
        {
            Id = id;
            Name = name;
            // TODO: Initialize the rest of the fields
            // ....................................
            Address = address;
            Phone = phone;
            Sin = sin;
            DateOfBirth = dateOfBirth;
            Department = department;
        }

        public Employee()
        {
        }
        public override string ToString()
        {
            return $"\n\tID: {Id} \n\tName: {Name}, \n\tAddress: {Address} \n\tPhone: {Phone} \n\tDepartment: {Department}";
        }
    }
}
