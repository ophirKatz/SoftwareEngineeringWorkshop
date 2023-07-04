namespace Example.SRP;

public class SRPBad
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public double CalculatePay()
        {
            return 100.0;
        }

        public Task SaveData()
        {
            return Db.Save(this);
        }

        public void SendMessage(string message)
        {
            SMS.Send(this, message);
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