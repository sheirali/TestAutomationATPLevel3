using System;
using System.Collections.Generic;
using Unicorn;

namespace Unicorn
{
    public class BaseApp : IDisposable
    {
        public static T Resolve<T>()
        {
            T result = ServiceContainer.Resolve<T>();
            return result;
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> result = ServiceContainer.ResolveAll<T>();
            return result;
        }

        public static void Register<TFrom, TTo>()
            where TTo : TFrom
        {
            ServiceContainer.Register<TFrom, TTo>();
        }

        public static void Register<TFrom, TTo>(string name)
            where TTo : TFrom
        {
            ServiceContainer.Register<TFrom, TTo>(name);
        }

        public static void ResisterInstance<TFrom>(TFrom instance)
        {
            ServiceContainer.ResisterInstance<TFrom>(instance);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
