using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    /// <summary>
    /// Contains the 4 quadrants of the quadtree
    /// <list type="quadrants">
    /// <listheader>Quadrants</listheader>
    /// <item>North west</item>
    /// <item>North east</item>
    /// <item>South west</item>
    /// <item>South east</item>
    /// </list>
    /// </summary>
    /// <typeparam name="T">Should behave like shape</typeparam>
    public class Quadrants<T> where T : IAmShape
    {
        #region Fields

        private const int QUADRANT_COUNT = 4;
        private QuadTree<T>[] quadrants = new QuadTree<T>[QUADRANT_COUNT];

        #endregion

        #region Quadtree Operations

        public bool Insert(T newNode)
        {
            for (int i = 0; i < QUADRANT_COUNT; i++)
            {
                if (quadrants[i].Insert(newNode)) return true;
            }

            return false;
        }

        public List<T> Query(Circle range, List<T> foundedNodes)
        {
            for (int i = 0; i < QUADRANT_COUNT; i++)
            {
                foundedNodes = quadrants[i].Query(range, foundedNodes);
            }

            return foundedNodes;
        }

        public List<T> Query(Rectangle range, List<T> foundedNodes)
        {
            for (int i = 0; i < QUADRANT_COUNT; i++)
            {
                foundedNodes = quadrants[i].Query(range, foundedNodes);
            }

            return foundedNodes;
        }

        public void ClearAllNodes()
        {
            for (int i = 0; i < QUADRANT_COUNT; i++)
            {
                quadrants[i].ClearAllNodes();
            }
        }

        #endregion

        #region Helpers

        public void Subdivide(Rectangle boundry, int capacity)
        {
            float x = boundry.centerX;
            float y = boundry.centerY;
            float w = boundry.halfOfWidth;
            float h = boundry.halfOfHeight;

            Rectangle nwBoundry = new Rectangle((x - w / 2), (y + h / 2), w / 2, h / 2);
            quadrants[0] = new QuadTree<T>(nwBoundry, capacity);

            Rectangle neBoundry = new Rectangle((x + w / 2), (y + h / 2), w / 2, h / 2);
            quadrants[1] = new QuadTree<T>(neBoundry, capacity);

            Rectangle swBoundry = new Rectangle((x - w / 2), (y - h / 2), w / 2, h / 2);
            quadrants[2] = new QuadTree<T>(swBoundry, capacity);

            Rectangle seBoundry = new Rectangle((x + w / 2), (y - h / 2), w / 2, h / 2);
            quadrants[3] = new QuadTree<T>(seBoundry, capacity);
        }

        public void ShowBoundries()
        {
            for (int i = 0; i < QUADRANT_COUNT; i++)
            {
                quadrants[i].ShowBoundries();
            }
        }

        #endregion
    }
}

