using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    public abstract class Shape
    {
        public float centerX;
        public float centerY;

        public abstract bool Contains(float otherX, float otherY);
        public abstract bool Intersects(Rectangle other);
        public abstract bool Intersects(Circle other);
        public abstract bool Intersects(Shape shape);
    }
}

