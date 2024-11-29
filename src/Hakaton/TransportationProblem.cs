namespace Hakaton;

public static class TransportationProblem
{
    public static (int summary, int[,] allocation) SolveByMinimalCost(int[,] cost, Span<int> supplies, Span<int> demands)
    {
        int[,] allocations = new int[supplies.Length, demands.Length];
        int summary = 0;

        while (true)
        {
            int minCost = int.MaxValue;
            int minRow = -1, minCol = -1;

            // Search for min cost
            for (int sup_i = 0; sup_i < supplies.Length; ++sup_i)
            {
                for (int dem_i = 0; dem_i < demands.Length; ++dem_i)
                {
                    if (supplies[sup_i] > 0 && demands[dem_i] > 0 && cost[sup_i, dem_i] < minCost)
                    {
                        minCost = cost[sup_i, dem_i];
                        (minRow, minCol) = (sup_i, dem_i);
                    }
                }
            }

            if (minRow == -1 || minCol == -1) break;

            // if a supplier has less shipments than a demand has, then we take all shipments from supplier
            // else we take all shipments from demands 
            int shipment = Math.Min(supplies[minRow], demands[minCol]);
            allocations[minRow, minCol] = shipment;

            // Update shipments
            supplies[minRow] -= shipment;
            demands[minCol] -= shipment;

            summary += shipment * cost[minRow, minCol];
        }

        return (summary, allocations);
    }
}