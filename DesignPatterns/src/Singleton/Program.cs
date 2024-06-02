var loadBalancer = LoadBalancer.GetLoadBalancer();

for (int i = 0; i < 20; i++)
{
    var serverName = loadBalancer.NextServer.Name;
    
    Console.WriteLine($"Request sent to: {serverName}");
}

Console.ReadKey();

public sealed class LoadBalancer
{
    // Load balancer instance is immediately initialized when class is loaded for the first time. 
    private static readonly LoadBalancer Instance = new();

    private readonly List<Server> _servers;

    private readonly Random _random = new();

    private LoadBalancer()
    {
        _servers = new List<Server>
        {
            new Server("Apollo", "125.22.120.3"),
            new Server("Hera", "125.22.120.4"),
            new Server("Poseidon", "125.22.120.5"),
            new Server("Zeus", "125.22.120.6"),
            new Server("Hestia", "125.22.120.7"),
            new Server("Dionysus", "125.22.120.8")
        };
    }

    public static LoadBalancer GetLoadBalancer()
    {
        return Instance;
    }

    public Server NextServer => _servers[_random.Next(_servers.Count)];
}

public record Server (string Name, string Ip);