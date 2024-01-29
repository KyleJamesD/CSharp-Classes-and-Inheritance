using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab2
{
    class Program
    {
        // Read data from the input file and fill into the list of employees
        static List<Employee> LoadEmployeesListFromFile(string filePath)
        {
            List<Employee> employees = new List<Employee>(); // create an empty list of data type Class Employees
            string[] fileLines = File.ReadAllLines(filePath); // create array of strings from the filepath variable which is referncing a text datafile. uses method File."ReadAllLines" from the "File" class that is apart of the System.io namespace in .NET. 
            // right now our array looks like this
            // ["634567:Fred Flintstone:34 Flintrock Way, Bedrock, BC:(345) 295-9076:678453234:June 15, 2000 BC:Pediatrics:44:27.85" , <<<<first string index[0]
            // "217546:Samuel Ludlow III:2345 The Rich Man Way, RichVille, RC:(567) 324-9812:768956453:February 29, 1942:Collections Section:20500" , <<<<<second string index [1]
            // "86595:Bill Partley:11 Partway Road, Almost, NW:(111) 232-9876:876345987:July 10, 1966:Parts Stuff:18:20.55" , "Next line"  , "Next Line" , etc etc....]
            // the key take away here is each line is One string in the array untill we apply a delimeter




            foreach (string line in fileLines) // For each element (which is the total string line still) in the fileLines array  
            {
                if (line != "") //  ( If line is not Blank  )
                {
                    string[] fields = line.Split(':'); // create new array of strings with delimter of : . the fields array will  look like [ "634567" : "Fred Flintstone " : "34 Flintrock Way, Bedrock, BC" :
                                                       // "(345) 295-9076:678453234:June 15, 2000 BC" : "Pediatrics" :"44" : "27.85" "next line individual strings" etc etc]
                    string id = fields[0]; // takes the first index 0 string from the array fields and store in variable id
                    char id_firstChar = id[0];// this is a tricky part an interesting thing about C# is strings are actully kinda like arrays, this takes the first index number of the string and assigns it to variable id_firstChar with a data type of char,
                                              // I think we could make this work with just string data type instead of char as well
                    switch (id_firstChar) 
                        //Matches ID in case statments and creates a "Child object" from either "salaried"  "Wages"  or "parttime" -- Derived classes from Parent Employee Class (the base class)
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                            employees.Add(new Salaried(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7])));
                            break;
                        // TODO: Add cases for other types of employees
                        // ...........................................
                        case '5':
                        case '6':
                        case '7':
                            employees.Add(new Wages(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7]), Double.Parse(fields[8])));
                            break;


                        case '8':
                        case '9':

                            employees.Add(new PartTime(fields[0], fields[1], fields[2], fields[3],
                                                       long.Parse(fields[4]), fields[5],
                                                       fields[6], Double.Parse(fields[7]),Double.Parse(fields[8])));
                            break;
                            // can write a default: case if you wanted something to happen if no match occoured from the cases.
                    }
                }
            }
            return employees;
        }


        // Returns the average pay of all employees.
        static double AveragePay(List<Employee> employees)
        {

            double totalPay = 0;
            foreach (Employee emp in employees) // for each Employee object in employees array
            {
                if (emp is Salaried)
                {
                    totalPay += ((Salaried)emp).GetPay();
                }
                // TODO: Implement the necessary code to calculate the average for all employees
                // ...........................................
                if (emp is PartTime)
                {
                    totalPay += ((PartTime)emp).GetPay();
                }
                if (emp is Wages)
                {
                    totalPay += ((Wages)emp).GetPay();
                }
            }
            return Math.Round(totalPay / employees.Count(), 2);
        }
        
		// Returns the Wages employee with the highest pay.		 
        static Wages HighestPayWagesEmployee(List<Employee> employees) // requires a paramter of an array called employees made from the class Employees. we declared this above on line 13 ***WRONG!*** This is a LIST NOT AN ARRAY there is a difference
        {
            double highestPay = 0;
            Wages highestPayEmp = null; // cannot set to zero because we want to return the object, thus set to null. kinda like saying the data type for variable HighestPayEmp is a Wage object
            for (int i = 0; i < employees.Count(); i++)
            {
                Employee emp = employees[i]; // emp variable is = to index # [I] as it iterates through employees array.
                if (emp is Wages) // This will iterate through all the objects in employees array and some of those are objects from salary and parttime classes, this only allows Wage objects to pass through to next if statement.
                {
                    Wages wageEmp = (Wages)emp; // this is a very weird line of code, but i think its basically transfering the object from one variabel to the next. I guess this is called casting but I dont understand the difference yet.
                    if (wageEmp.GetPay() > highestPay)  // uses the Getpay function to compare the Objects wage to the variable highest pay. If it is greater then it assigns that object to variable highestPay.
                    {
                        highestPay = wageEmp.GetPay();
                        highestPayEmp = wageEmp;
                    }
                }
            }
            return highestPayEmp; // returns the object not the weekly pay.
        }

        // Returns the Salaried employee with the lowest pay.		 
        static Salaried LowestPaySalariedEmployee(List<Employee> employees)
        {
            Salaried lowestPayEmp = null;
            // TODO: Implement the necessary code to get the employee with lowest payment
            // ...........................................
            double lowestPay = 10000000;
            for (int i = 0; i < employees.Count(); i++)
            {
                Employee emp = employees[i];
                if (emp is Salaried)
                {
                    Salaried wageEmp = (Salaried)emp;
                    if (wageEmp.GetPay() < lowestPay)
                    {
                        lowestPay = wageEmp.GetPay();
                        lowestPayEmp = wageEmp;
                    }
                }
            }

            return lowestPayEmp;
        }
        
		// Returns the percentage of Salaried employees.
        static double PercentageOfSalaried(List<Employee> employees)
        {
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Salaried)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);
        }

		 // Returns the percentage of Wages employees.
        static double PercentageOfWages(List<Employee> employees)
        {
            // TODO: Implement the necessary code to calculate percentage of the wages employees
            // ...........................................
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is Wages)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);

        }
        
		// Returns the percentage of PartTime employees.
        static double PercentageOfPartTime(List<Employee> employees)
        {
            // TODO: Implement the necessary code to calculate percentage of the PartTime employees
            // ...........................................
            int count = 0;
            foreach (Employee emp in employees)
            {
                if (emp is PartTime)
                {
                    count++;
                }
            }
            return Math.Round((double)count / employees.Count() * 100, 2);


        }

        static void Main(string[] args)
        {
            string inputFilePath = @"../../data/employees.txt";
            List<Employee> employees = LoadEmployeesListFromFile(inputFilePath);

            Console.WriteLine($"The average pay for all employees is: {AveragePay(employees)}");

            Wages wage_emp = HighestPayWagesEmployee(employees);
            Console.WriteLine($"The Wages employee with the highest pay is: {wage_emp} \n\twith salary of {wage_emp.GetPay()}");

            Salaried salaried_emp = LowestPaySalariedEmployee(employees);
            Console.WriteLine($"The Salaried employee with the lowest pay is: {salaried_emp} \n\twith salary of {salaried_emp.GetPay()}");

            Console.WriteLine($"Percentage of Salaried employees is: {PercentageOfSalaried(employees)} %");
            Console.WriteLine($"Percentage of Wages employees is: {PercentageOfWages(employees)} %");
            Console.WriteLine($"Percentage of Part Time employees is: {PercentageOfPartTime(employees)}%");

            Console.ReadKey();
        }
    }
}
