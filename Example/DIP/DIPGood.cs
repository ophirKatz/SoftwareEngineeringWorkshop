namespace Example.DIP;

public class DIPGood
{
    public interface IEmployeeRaiseGiver
    {
        void GiveRaise(double raise);
    }

    public interface IEmployeeRaiseNotifier
    {
        event EventHandler<double> RaiseGiven;
    }

    public class EmployeePayManager : IEmployeeRaiseGiver, IEmployeeRaiseNotifier
    {
        public void GiveRaise(double raise)
        {
            RaiseGiven.Invoke(this, raise);
        }

        public event EventHandler<double> RaiseGiven;
    }

    public class EmployeeManager
    {
        private readonly IEmployeeRaiseGiver _giver;

        public EmployeeManager(IEmployeeRaiseGiver giver)
        {
            _giver = giver;
        }

        public void GiveRaise(double raise)
        {
            _giver.GiveRaise(raise);
        }
    }

    public class EmployeeMessageSender
    {
        private readonly IEmployeeRaiseNotifier _notifier;

        public EmployeeMessageSender(IEmployeeRaiseNotifier notifier)
        {
            _notifier = notifier;
            _notifier.RaiseGiven += OnRaiseGiven;    // TODO : Unregister
        }

        private void OnRaiseGiven(object? sender, double e)
        {
            SMS.Send($"Raise of {e} percent given");
        }
    }

    internal static class SMS
    {
        internal static void Send(string message)
        {
        }
    }
}