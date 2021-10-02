using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    [RequireComponent(typeof(MeshRenderer))]
    internal class Unit : MonoBehaviour, IAmCircle
    {
        #region Fields

        private MeshRenderer meshRenderer;
        private MaterialPropertyBlock propBlock;

        [SerializeField] private float speed;
        private Circle circle;

        #endregion

        #region Properties

        public Circle Circle { get => circle; private set => circle = value; }

        #endregion

        #region Unity Lifecycle Functions

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            propBlock = new MaterialPropertyBlock();

            Circle = new Circle(meshRenderer.bounds.center.x, meshRenderer.bounds.center.z, meshRenderer.bounds.extents.x);

            transform.rotation = GetRandomDirection();
        }

        #endregion

        #region Movement

        public void Move(QuadTree<Unit> _quadTree, float deltaTime)
        {
            Vector3 newPosition = transform.position + transform.forward * speed * deltaTime;
            bool isNewPositionValid = _quadTree.IsPositionValid(newPosition.x, newPosition.z);

            if (isNewPositionValid)
            {
                transform.position = newPosition;
            }
            else
            {
                transform.rotation = GetRandomDirection();
            }

            Circle.centerX = meshRenderer.bounds.center.x;
            Circle.centerY = meshRenderer.bounds.center.z;
        }

        private Quaternion GetRandomDirection()
        {
            Quaternion randomDir = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
            return randomDir;
        }

        #endregion

        #region Helpers

        public void SetColor(Color newColor)
        {
            meshRenderer.GetPropertyBlock(propBlock);
            propBlock.SetColor("_Color", newColor);
            meshRenderer.SetPropertyBlock(propBlock);
        }

        internal bool IsCollide(Unit other)
        {
            if (other == this) return false;

            return Circle.Intersects(other.Circle);
        }

        public Shape GetShape()
        {
            return Circle;
        }

        #endregion
    }
}


