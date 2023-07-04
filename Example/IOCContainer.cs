namespace Example;

// Bonus: Apply the ISP principle here
public class IOCContainer   // Or DIContainer
{
    private static readonly IDictionary<Type, Type> Services = new Dictionary<Type, Type>();

    public static void Register(Type dependency, Type implementation)
    {
        Services.Add(new KeyValuePair<Type, Type>(dependency, implementation));
    }

    public static object GetDependency(Type dependency)
    {
        var implementationType = Services[dependency];
        return Activator.CreateInstance(implementationType)!;
    }
}