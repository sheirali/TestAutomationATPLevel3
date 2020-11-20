﻿using System;
using System.Collections.Generic;
using Unity;
using Unity.Lifetime;

namespace Unicorn.Container
{
    public static class ServiceContainer
    {
        private static readonly IUnityContainer _container;
        private static readonly object _lockObject = new object();

        static ServiceContainer()
        {
            _container = new UnityContainer();
        }

        public static T Resolve<T>()
        {
            T result = _container.Resolve<T>();
            return result;
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            IEnumerable<T> result = _container.ResolveAll<T>();
            return result;
        }

        public static void Register<TFrom, TTo>()
            where TTo : TFrom
        {
            lock (_lockObject)
            {
                _container.RegisterType<TFrom, TTo>();
            }
        }

        public static void Register<TFrom, TTo>(string name)
            where TTo : TFrom
        {
            lock (_lockObject)
            {
                _container.RegisterType<TFrom, TTo>(name);
            }
        }

        public static void ResisterInstance<TFrom>(TFrom instance)
        {
            _container.RegisterInstance<TFrom>(instance);
        }
    }
}
