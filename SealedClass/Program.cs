using System;

interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}

class Employee : IEmployee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee()
    {
        Id = 0;
        FirstName = string.Empty;
        LastName = string.Empty;
    }
    public Employee(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string Fullname()
    {
        return FirstName + " " + LastName;
    }
    public virtual double Pay()
    {
        double salary;
        Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
        salary = double.Parse(Console.ReadLine());
        return salary;
    }
}

sealed class Executive : Employee
{
    public string Title { get; set; }
    public double Salary { get; set; }

    public Executive()
    {
        Title = string.Empty;
        Salary = 0.0;
    }
    public Executive(int id, string firstName, string lastName, string title, double salary)
        : base(id, firstName, lastName)
    {
        Title = title;
        Salary = salary;
    }
    public override double Pay()
    {
        Console.WriteLine($"What is {this.Fullname()}'s bi-weekly salary?");
        double biweeklySalary = double.Parse(Console.ReadLine());
        return biweeklySalary / 2.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee(1, "Bilbo", "Baggins");
        Console.WriteLine("Employee Information:");
        Console.WriteLine($"ID: {employee.Id}\nName: {employee.Fullname()}\nWeekly Salary: {employee.Pay()}");

        Executive executive = new Executive(2, "Gandalf", "Greyhame", "CEO", 100000.0);
        Console.WriteLine("\nExecutive Information:");
        Console.WriteLine($"ID: {executive.Id}\nName: {executive.Fullname()}\nTitle: {executive.Title}\nBi-Weekly Salary: {executive.Pay()}");

        Console.ReadLine();
    }
}
