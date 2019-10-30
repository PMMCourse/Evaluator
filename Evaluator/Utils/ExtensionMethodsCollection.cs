using System;
using System.Collections.Generic;

namespace Evaluator.Utils
{
    public static class ExtensionMethodsCollection
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> execute)
        {
            foreach(var elem in collection)
            {
                execute.Invoke(elem);
            }
        }
    }
}
