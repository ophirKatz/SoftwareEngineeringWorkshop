namespace Example.SRP;

public class SRPGood
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    internal static class PayCalculator
    {
        internal static double Calculate(Employee emp)
        {
            return 100.0;
        }
    }

    internal static class EmployeeSaver
    {
        internal static Task Save(Employee emp)
        {
            return Db.Save(emp);
        }
    }

    internal static class EmployeeMessageSender
    {
        internal static void Send(Employee emp, string message)
        {
            SMS.Send(emp, message);
        }
    }

    internal static class Db
    {
        internal static Task Save(Employee emp)
        {
            return Task.CompletedTask;
        }
    }

    internal static class SMS
    {
        internal static void Send(Employee emp, string message)
        {
        }
    }

    #region Change

    internal static class File
    {
        internal static Task Save(Employee emp)
        {
            return Task.CompletedTask;
        }
    }

    internal static class Email
    {
        internal static void Send(Employee emp, string message)
        {
        }
    }

    #endregion
}