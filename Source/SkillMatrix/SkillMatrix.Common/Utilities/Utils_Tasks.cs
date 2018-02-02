using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {
        public static Task ContinueWhenAll(this IEnumerable<Task> tasks, Action<Task[]> continueWith)
        {
            if (tasks != null)
            {
                var tasksArray = tasks.ToArray();
                if (tasksArray.Any())
                {
                    return Task.Factory.ContinueWhenAll(tasksArray.ToArray(), continueWith);
                }
            }
            return Task.Factory.StartNew(() => continueWith(new Task[]{}));
        }
    }
}