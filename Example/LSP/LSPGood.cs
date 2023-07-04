namespace Example.LSP;

public class LSPGood
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual double CalculateRaisePercentage()
        {
            return 0.02;
        }
    }

    public class TenureEmployee : Employee
    {
        public TenureEmployee(string name) : base(name)
        {
        }

        public override double CalculateRaisePercentage()
        {
            return 0.04;
        }
    }
}