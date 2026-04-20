using System;
using System.Collections.Generic;

namespace Architectures.ServiceLocatorArchitecture
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            _services[typeof(T)] = service;
        }

        public static T Get<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out object service) == false)
            {
                throw new InvalidOperationException($"Service of type {typeof(T).Name} was not registered.");
            }

            return (T)service;
        }

        public static bool TryGet<T>(out T service) where T : class
        {
            if (_services.TryGetValue(typeof(T), out object value))
            {
                service = (T)value;
                return true;
            }

            service = null;
            return false;
        }

        public static void Clear()
        {
            foreach (object service in _services.Values)
            {
                if (service is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }

            _services.Clear();
        }
    }
}
