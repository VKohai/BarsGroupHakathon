var input = File.ReadAllLines("in.txt");
// N - Suppliers, M - Consumers
var (N, M) = input[0].Split().Select(int.Parse).ToArray() switch { var arr => (arr[0], arr[1]) };
var supplies = input[1].Split().Select(int.Parse).ToArray();
var demands = input[2].Split().Select(int.Parse).ToArray();

var costs = new int[N, M];

Parallel.For(0, N, i =>
{
    var costLine = input[3 + i].Split().Select(int.Parse).ToArray();
    for (int j = 0; j < M; ++j)
        costs[i, j] = costLine[j];
});