namespace Example.LSP;

public class LSPBad
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void Fire()  // לפטר יענו
        {
            
        }
    }

    public class TenureEmployee : Employee
    {
        public TenureEmployee(string name) : base(name)
        {
        }

        public override void Fire()
        {
            // Sorry, we can't fire employees with tenure
            throw new NotImplementedException();
        }
    }
}