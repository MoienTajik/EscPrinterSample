using System;
using System.Threading;
using System.Threading.Tasks;

namespace EscPrinterTest
{
    public static class TaskExtensions
    {
        public static async Task WithCancellationToken(this Task task, CancellationToken cancellationToken)
        {
            Task completedTask = await Task.WhenAny(task, Task.Delay(TimeSpan.FromMinutes(45), cancellationToken));

            if (completedTask == task)
            {
                await task; // Very important in order to propagate exceptions
            }
            else
            {
                throw new TimeoutException("The operation has timed out.");
            }
        }
    }
}