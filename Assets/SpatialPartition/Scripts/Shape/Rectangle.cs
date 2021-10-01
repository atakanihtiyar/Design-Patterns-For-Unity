using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    public class Rectangle : Shape
    {
        public float halfOfWidth;
        public float halfOfHeight;

        public Rectangle(float centerX, float centerY, float halfOfWidth, float halfOfHeight)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.halfOfWidth = halfOfWidth;
            this.halfOfHeight = halfOfHeight;
        }

        public override bool Contains(float otherX, float otherY)
        {
            bool isInRangeX = otherX >= (centerX - halfOfWidth) && otherX <= (centerX + halfOfWidth);
            bool isInRangeY = otherY >= (centerY - halfOfHeight) && otherY <= (centerY + halfOfHeight);

            return isInRangeX && isInRangeY;
        }

        public override bool Intersects(Rectangle other)
        {
            bool isInRangeX = !((other.centerX - other.halfOfWidth > centerX + halfOfWidth) || (other.centerX + other.halfOfWidth < centerX - halfOfWidth));
            bool isInRangeY = !((other.centerY - other.halfOfHeight > centerY + halfOfHeight) || (other.centerY + other.halfOfHeight < centerY - halfOfHeight));

            return isInRangeX && isInRangeY;
        }

        public override bool Intersects(Circle other)
        {
            float Xn = Mathf.Max(centerX - halfOfWidth, Mathf.Min(other.centerX, centerX + halfOfWidth));
            float Yn = Mathf.Max(centerY - halfOfHeight, Mathf.Min(other.centerY, centerY + halfOfHeight));

            float Dx = Xn - other.centerX;
            float Dy = Yn - other.centerY;

            return (Dx * Dx + Dy * Dy) <= other.radius * other.radius;
        }

        public override bool Intersects(Shape shape)
        {
            return shape.Intersects(this);
        }
    }
}

