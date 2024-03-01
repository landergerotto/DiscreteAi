using System;
using System.Collections.Generic;
using System.Linq;

using AulasAI;
using AulasAI.Nuenv;
using AulasAI.Rocket;
using AulasAI.Optimize;

int numberOfPoints = 11;
var timeData = Space.Geometric(1.0, 501.0, numberOfPoints).Select(x => x - 1.0).ToArray();

double Simulate(double[] massFlowData)
{
    var rocket = new Rocket(
        750.0,
        Math.PI * 0.6 * 0.6 / 4.0,
        1916.0,
        0.8,
        timeData,
        massFlowData
    );

    return rocket.LaunchUntilMax();
}

double FitnessEvol(double[] x) => -1.0 * Simulate(x);

double FitnessGD(double[] x) 
{   
    var combTotal = Integrate.Romberg(timeData, x);
    var penalty = combTotal - 3500.0;

    var minimize = -1.0 * Simulate(x);

    return minimize + penalty;
}


double Restriction(double[] x)
    => Integrate.Romberg(timeData, x) - 3500.0;

var bounds = new List<double[]>(numberOfPoints);
for (int i = 0; i < numberOfPoints; i++)
    bounds.Add(new double[] { 0.0, 1000.0 });

var diffEvol = new DiffEvolution(FitnessEvol, bounds, 15 * numberOfPoints, Restriction);
var sol = diffEvol.Optimize(1000);

foreach (var s in sol)
    Console.WriteLine(s);

Console.WriteLine($"Altitude maxima: {Simulate(sol)}");














