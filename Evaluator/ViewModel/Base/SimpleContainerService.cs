using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluator.ViewModel.Base
{
    public static class SimpleContainerService
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void Register<T>(object implementation) => _services[typeof(T)] = implementation;

        public static T Get<T>() => (T)_services[typeof(T)];


    }
}
