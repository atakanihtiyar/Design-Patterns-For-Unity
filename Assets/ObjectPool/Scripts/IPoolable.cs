using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    /// <summary>
    /// Interface for objects to be added to <c>ObjectPool</c>.
    /// </summary>
    public interface IPoolable
    {
        void OnSpawn();
    }
}
