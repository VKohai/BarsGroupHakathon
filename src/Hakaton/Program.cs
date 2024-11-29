using Hakaton;

var input = File.ReadAllLines("in.txt");
// N - Suppliers, M - Consumers
var (N, M) = input[0].Split().Select(int.Parse).ToArray() switch { var arr => (arr[0], arr[1]) };
var supplies = input[1].Split().AsParallel().Select(int.Parse).ToArray();
var demands = input[2].Split().AsParallel().Select(int.Parse).ToArray();

var costs = new int[N, M];

Parallel.For(0, M, i =>
{
    var costLine = input[3 + i].Split().Select(int.Parse).ToArray();
    for (int j = 0; j < N; ++j)
        costs[i, j] = costLine[j];
});


var (summary, allocations) = TransportationProblem.SolveByMinimalCost(costs, supplies, demands);

using var writer = new StreamWriter("out.txt");

writer.WriteLine(summary);

for (int i = 0; i < allocations.GetLength(0); ++i)
{
    for (int j = 0; j < allocations.GetLength(1); ++j)
    {
        writer.Write($"{allocations[i, j]} ");
    }
    writer.WriteLine();
}