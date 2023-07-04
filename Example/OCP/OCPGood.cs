namespace Example.OCP;

public class OCPGood
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    internal class EmployeeMessageSendingHandler
    {
        private readonly EmployeeMessageSender _sender;

        public EmployeeMessageSendingHandler()
        {
            // Is this good enough?
            _sender = new SMSEmployeeMessageSender();
        }

        public void SendMessage(Employee emp, string message)
        {
            _sender.Send(emp, message);
        }
    }

    internal abstract class EmployeeMessageSender
    {
        public abstract void Send(Employee emp, string message);
    }

    internal class SMSEmployeeMessageSender : EmployeeMessageSender
    {
        public override void Send(Employee emp, string message)
        {
            SMS.Send(emp, message);
        }
    }

    internal class EmailEmployeeMessageSender : EmployeeMessageSender
    {
        public override void Send(Employee emp, string message)
        {
            Email.Send(emp, message);
        }
    }

    internal class WhatsAppEmployeeMessageSender : EmployeeMessageSender
    {
        public override void Send(Employee emp, string message)
        {
            WhatsApp.Send(emp, message);
        }
    }

    internal static class SMS
    {
        internal static void Send(Employee emp, string message)
        {
        }
    }

    internal static class Email
    {
        internal static void Send(Employee emp, string message)
        {
        }
    }

    internal static class WhatsApp
    {
        internal static void Send(Employee emp, string message)
        {
        }
    }
}