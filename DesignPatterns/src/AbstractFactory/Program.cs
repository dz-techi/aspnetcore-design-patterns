IVehicleFactory factory;

Console.WriteLine("Choose Vehicle Type (1 - Electric, 2 - Gas):");
var choice = Console.ReadLine();

if (choice == "1")
{
    factory = new ElectricVehicleFactory();
}
else
{
    factory = new GasVehicleFactory();
}

var vehicle = new Vehicle(factory);
vehicle.Build();


// Interfaces
public interface IEngine
{
    void Design();
}

public interface ITire
{
    void Manufacture();
}

// Concrete vehicles and tires
public class ElectricEngine : IEngine
{
    public void Design()
    {
        Console.WriteLine("Designing Electric Engine.");
    }
}

public class ElectricTire : ITire
{
    public void Manufacture()
    {
        Console.WriteLine("Manufacturing Electric Tire.");
    }
}

public class GasEngine : IEngine
{
    public void Design()
    {
        Console.WriteLine("Designing Gas Engine.");
    }
}

public class GasTire : ITire
{
    public void Manufacture()
    {
        Console.WriteLine("Manufacturing Gas Tire.");
    }
}

// Vehicle Factory
public interface IVehicleFactory
{
    IEngine CreateEngine();
    ITire CreateTire();
}

public class ElectricVehicleFactory : IVehicleFactory
{
    public IEngine CreateEngine()
    {
        return new ElectricEngine();
    }

    public ITire CreateTire()
    {
        return new ElectricTire();
    }
}

public class GasVehicleFactory : IVehicleFactory
{
    public IEngine CreateEngine()
    {
        return new GasEngine();
    }

    public ITire CreateTire()
    {
        return new GasTire();
    }
}

public class Vehicle
{
    private readonly IEngine _engine;
    private readonly ITire _tire;

    public Vehicle(IVehicleFactory factory)
    {
        _engine = factory.CreateEngine();
        _tire = factory.CreateTire();
    }

    public void Build()
    {
        _engine.Design();
        _tire.Manufacture();
    }
}