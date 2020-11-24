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

        public static void RegisterType<TFrom, TTo>()
            where TTo : TFrom
        {
            ServiceContainer.RegisterType<TFrom, TTo>();
        }

        public static void RegisterType<TFrom, TTo>(string name)
            where TTo : TFrom
        {
            ServiceContainer.RegisterType<TFrom, TTo>(name);
        }

        public static void RegisterInstance<TFrom>(TFrom instance)
        {
            ServiceContainer.RegisterInstance<TFrom>(instance);
        }

        public static void UnRegisterInstance<TFrom>()
        {
            ServiceContainer.UnRegisterInstance<TFrom>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
