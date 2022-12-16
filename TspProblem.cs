namespace tsp2;
class TspProblem
{
    public List<City> Cities { get; set; }

    public TspProblem(List<City> cities)
    {
        Cities = cities;
    }

    public double GetDistance(City city1, City city2)
    {
        // Calculate the Euclidean distance between the two cities
        double dx = city1.X - city2.X;
        double dy = city1.Y - city2.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public List<List<City>> GetAllRoutes()
    {
        var routes = new List<List<City>>();
        GetAllRoutesRecursive(Cities, new List<City>(), routes);
        return routes;
    }

    private void GetAllRoutesRecursive(List<City> cities, List<City> route, List<List<City>> routes)
    {
        if (cities.Count == 0)
        {
            // Add the current route to the list of routes
            routes.Add(route);
            return;
        }

        // Generate all possible routes by adding each city to the current route and recursively
        // generating all possible routes from the remaining cities
        foreach (var city in cities)
        {
            var newRoute = new List<City>(route);
            newRoute.Add(city);
            var remainingCities = new List<City>(cities);
            remainingCities.Remove(city);
            GetAllRoutesRecursive(remainingCities, newRoute, routes);
        }
    }

    public double GetRouteDistance(List<City> route)
    {
        double distance = 0.0;
        for (int i = 0; i < route.Count - 1; i++)
        {
            distance += GetDistance(route[i], route[i + 1]);
        }
        return distance;
    }

    public List<City> GetShortestRoute()
    {
        var routes = GetAllRoutes();
        List<City> shortestRoute = new List<City>();
        double shortestDistance = double.MaxValue;
        foreach (var route in routes)
        {
            double distance = GetRouteDistance(route);
            if (distance < shortestDistance)
            {
                shortestRoute = route;
                shortestDistance = distance;
            }
        }
        return shortestRoute;
    }
}

