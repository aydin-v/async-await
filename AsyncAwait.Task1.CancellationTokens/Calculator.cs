using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    public async static Task<long> CalculateAsync(int n, CancellationToken token)
    {
        return await Task
                .Run(() =>
                {
                    long sum = 0;
                    for (var i = 0; i < n; i++)
                    {
                        token.ThrowIfCancellationRequested();

                        sum += i + 1;
                        Thread.Sleep(10);
                    }
                    return sum;
                },token);
    }
}
