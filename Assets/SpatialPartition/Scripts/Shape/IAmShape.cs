using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    /// <summary>
    /// Interface for 3d objects to behave like shape
    /// </summary>
    public interface IAmShape
    {
        Shape GetShape();
    }
}

