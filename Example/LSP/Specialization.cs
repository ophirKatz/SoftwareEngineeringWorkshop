namespace Example.LSP;

public class Specialization
{
    public enum EmployeeType
    {
        Normal,
        Tenure
    }

    public class Employee
    {
        public Employee(string name, EmployeeType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public EmployeeType Type { get; set; }

        public double CalculateRaisePercentage()
        {
            return Type switch
            {
                EmployeeType.Normal => 0.02,
                EmployeeType.Tenure => 0.04,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    // Specialization:

    public abstract class EmployeeSpecialized
    {
        protected EmployeeSpecialized(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract double CalculateRaisePercentage();
    }

    public class NormalEmployeeSpecialized : EmployeeSpecialized
    {
        public NormalEmployeeSpecialized(string name) : base(name)
        {
        }

        public override double CalculateRaisePercentage()
        {
            return 0.02;
        }
    }

    public class TenureEmployeeSpecialized : EmployeeSpecialized
    {
        public TenureEmployeeSpecialized(string name) : base(name)
        {
        }

        public override double CalculateRaisePercentage()
        {
            return 0.04;
        }
    }
}