using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    /// <summary>
    /// Interface for 3d objects to behave like circle
    /// </summary>
    public interface IAmCircle : IAmShape
    {
        Circle Circle { get; }
    }
}

