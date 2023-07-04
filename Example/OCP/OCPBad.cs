namespace Example.OCP;

public class OCPBad
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    internal enum MessageType
    {
        SMS,
        Email,
        //WhatsApp
    }

    internal static class EmployeeMessageSender
    {
        public static void SendMessage(Employee emp, MessageType type, string message)
        {
            switch (type)
            {
                case MessageType.SMS:
                    SMS.Send(emp, message);
                    break;
                case MessageType.Email:
                    Email.Send(emp, message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
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