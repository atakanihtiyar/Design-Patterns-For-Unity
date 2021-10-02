using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ServiceLocator
{
    /// <typeparam name="T">Service type</typeparam>
    public class ServiceLocator<T> : MonoBehaviour where T : new()
    {
        private static T _nullService;
        private static T _service;

        static ServiceLocator()
        {
            _nullService = new T();
            
            _service = _nullService;
        }

        public static T GetService()
        {
            return _service;
        }

        public static void SetService(T service)
        {
            if (service == null)
            {
                _service = _nullService;
            }
            else
            {
                _service = service;
            }
        }
    }
}

