using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    public class Circle : Shape
    {
        public float radius;

        public Circle(float centerX, float centerY, float radius)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
        }

        public override bool Contains(float otherX, float otherY)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(otherX - centerX, 2) + Mathf.Pow(otherY - centerY, 2));
            return distance < radius;
        }

        public override bool Intersects(Rectangle other)
        {
            float Xn = Mathf.Max(other.centerX - other.halfOfWidth, Mathf.Min(centerX, other.centerX + other.halfOfWidth));
            float Yn = Mathf.Max(other.centerY - other.halfOfHeight, Mathf.Min(centerY, other.centerY + other.halfOfHeight));

            float Dx = Xn - centerX;
            float Dy = Yn - centerY;

            return (Dx * Dx + Dy * Dy) <= radius * radius;
        }

        public override bool Intersects(Circle other)
        {
            float distance = Mathf.Sqrt(Mathf.Pow(other.centerX - centerX, 2) + Mathf.Pow(other.centerY - centerY, 2));
            return distance < other.radius + radius;
        }

        public override bool Intersects(Shape shape)
        {
            return shape.Intersects(this);
        }
    }
}

