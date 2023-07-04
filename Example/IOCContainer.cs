namespace Example;

// Bonus: Apply the ISP principle here
public class IOCContainer   // Or DIContainer
{
    private readonly IDictionary<Type, Type> _services = new Dictionary<Type, Type>();

    public void Register(Type dependency, Type implementation)
    {
        _services.Add(new KeyValuePair<Type, Type>(dependency, implementation));
    }

    public object GetDependency(Type dependency)
    {
        var implementationType = _services[dependency];
        return Activator.CreateInstance(implementationType)!;
    }
}