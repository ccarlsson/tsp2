
using tsp2;

var city1 = new City("City 1", 0.0, 0.0);
var city2 = new City("City 2", 5.0, 10.0);
var city3 = new City("City 3", 10.0, 5.0);
var city4 = new City("City 4", 3.6, 2.8);


var cities = new List<City> { city1, city2, city3, city4 };
var problem = new TspProblem(cities);

var shortestRoute = problem.GetShortestRoute();

System.Console.WriteLine(string.Join(" -> ", shortestRoute));