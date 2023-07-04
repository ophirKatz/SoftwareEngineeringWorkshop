namespace Example.ISP;

public class ISPBad
{
    public class EmployeePayManager
    {
        public void GiveRaise(double raise)
        {
            RaiseGiven.Invoke(this, raise);
        }

        public event EventHandler<double> RaiseGiven;
    }

    public class EmployeeManager
    {
        private readonly EmployeePayManager _manager;

        public EmployeeManager()
        {
            _manager = new EmployeePayManager();
        }

        public void GiveRaise(double raise)
        {
            _manager.GiveRaise(raise);
        }
    }

    public class EmployeeMessageSender
    {
        private readonly EmployeePayManager _manager;

        public EmployeeMessageSender()
        {
            _manager = new EmployeePayManager();
            _manager.RaiseGiven += OnRaiseGiven;    // TODO : Unregister
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