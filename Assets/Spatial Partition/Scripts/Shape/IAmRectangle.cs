using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns.SpatialPartition
{
    /// <summary>
    /// Interface for 3d objects to behave like rectangle
    /// </summary>
    public interface IAmRectangle : IAmShape
    {
        Rectangle Rectangle { get; }
    }
}