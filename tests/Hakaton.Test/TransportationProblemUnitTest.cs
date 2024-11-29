namespace Hakaton.Test;

public class TransportationProblemUnitTest
{
    [Fact]
    public void Test1()
    {
        const int N = 4, M = 3;
        var supplies = new int[] { 30, 40, 20 };
        var demands = new int[] { 20, 30, 30, 10 };

        var costs = new int[M, N]
        {
            {2, 3, 2, 4},
            {3, 2, 5, 1},
            {4, 3, 2, 6}
        };

        var (summary, allocations) = TransportationProblem.SolveByMinimalCost(costs, supplies, demands);

        var exceptedAllocation = new int[M, N] {
            {20, 0, 10, 0},
            {0, 30, 0, 10},
            {0, 0, 20, 0}
        };

        Assert.Equal(170, summary);
        Assert.Equal(exceptedAllocation, allocations);
    }
}
