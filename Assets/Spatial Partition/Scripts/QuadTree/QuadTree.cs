using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    /// <typeparam name="T">Should behave like shape</typeparam>
    public class QuadTree<T> where T : IAmShape
    {
        #region Fields

        private Quadrants<T> quadrants;

        private List<T> nodes;
        private Rectangle boundry;
        private int capacity;
        private bool isDivided = false;
        private bool isRoot = false;

        private Color drawingColor = Color.black;

        #endregion

        #region Constructor

        public QuadTree(Rectangle boundry, int capacity)
        {
            quadrants = new Quadrants<T>();
            nodes = new List<T>();

            this.boundry = boundry;
            this.capacity = capacity;
        }

        #endregion

        #region Quadtree Operations

        public bool Insert(T newNode)
        {
            if (!boundry.Contains(newNode.GetShape().centerX, newNode.GetShape().centerY)) return false;

            if (isRoot)
            {
                if (quadrants.Insert(newNode)) return true;
            }
            else if (nodes.Count < capacity)
            {
                nodes.Add(newNode);
                return true;
            }
            else
            {
                isRoot = true;
                if (isDivided == false) Subdivide();

                nodes.ForEach(node =>
                {
                    quadrants.Insert(node);
                });
                nodes.Clear();

                quadrants.Insert(newNode);

                return true;
            }

            return false;
        }

        public List<T> Query(Rectangle range, List<T> foundedNodes = null)
        {
            foundedNodes = foundedNodes == null ? new List<T>() : foundedNodes;

            if (!boundry.Intersects(range)) return foundedNodes;

            if (isRoot)
            {
                foundedNodes = quadrants.Query(range, foundedNodes);
                return foundedNodes;
            }
            else
            {
                nodes.ForEach(node =>
                {
                    if (range.Intersects(node.GetShape()))
                    {
                        foundedNodes.Add(node);
                    }
                });
                return foundedNodes;
            }
        }

        public List<T> Query(Circle range, List<T> foundedNodes = null)
        {
            foundedNodes = foundedNodes == null ? new List<T>() : foundedNodes;

            if (!boundry.Intersects(range)) return foundedNodes;

            if (isRoot)
            {
                foundedNodes = quadrants.Query(range, foundedNodes);
                return foundedNodes;
            }
            else
            {
                nodes.ForEach(node =>
                {
                    if (range.Intersects(node.GetShape()))
                    {
                        foundedNodes.Add(node);
                    }
                });
                return foundedNodes;
            }
        }

        public void ClearAllNodes()
        {
            nodes.Clear();
            isRoot = false;

            if (isDivided)
            {
                quadrants.ClearAllNodes();
            }
            isDivided = false;
        }

        #endregion

        #region Helpers

        private void Subdivide()
        {
            quadrants.Subdivide(boundry, capacity);
            isDivided = true;
        }

        internal bool IsPositionValid(float x, float z)
        {
            return boundry.Contains(x, z);
        }

        public void ShowBoundries()
        {
            float x = boundry.centerX;
            float y = boundry.centerY;
            float w = boundry.halfOfWidth;
            float h = boundry.halfOfHeight;

            Vector3 nwCorner = new Vector3(x - w, 2f, y + h);
            Vector3 neCorner = new Vector3(x + w, 2f, y + h);
            Vector3 swCorner = new Vector3(x - w, 2f, y - h);
            Vector3 seCorner = new Vector3(x + w, 2f, y - h);

            Debug.DrawLine(nwCorner, neCorner, drawingColor);
            Debug.DrawLine(nwCorner, swCorner, drawingColor);
            Debug.DrawLine(neCorner, seCorner, drawingColor);
            Debug.DrawLine(swCorner, seCorner, drawingColor);

            if (isDivided)
            {
                quadrants.ShowBoundries();
            }
        }

        #endregion
    }
}

