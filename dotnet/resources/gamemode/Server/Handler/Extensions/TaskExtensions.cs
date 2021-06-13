using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamemode.Server.Handler.Extensions
{
    public static class TaskExtensions
    {
        [ThreadStatic]
        public static bool IsMainThread = false;

        public static void RunSafe(this GTANetworkMethods.Task task, Action action)
        {
            try
            {
                if (IsMainThread)
                    action();
                else
                    task.Run(() =>
                    {
                        try
                        {
                            action();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("[ERROR] " + ex);
                        }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex);
            }
        }
        public static async Task RunWait(this GTANetworkMethods.Task task, Action action)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            RunSafe(task, () =>
            {
                action();
                taskCompletionSource.SetResult(true);
            });
            await taskCompletionSource.Task.ConfigureAwait(false);
        }

        public static Task<T> RunWait<T>(this GTANetworkMethods.Task task, Func<T> action)
        {
            var taskCompletionSource = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
            RunSafe(task, () =>
            {
                var result = action();
                taskCompletionSource.SetResult(result);
            });
            return taskCompletionSource.Task;
        }

        public static async void IgnoreResult(this Task task)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex);
            }
        }
    }
}
