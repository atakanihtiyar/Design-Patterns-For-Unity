using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.SpatialPartition
{
    internal class GameManager : MonoBehaviour
    {
        #region Fields

        [Header("Colors")]
        [SerializeField] private Color idleUnitColor = Color.white;
        [SerializeField] private Color collidingUnitColor = Color.red;
        [SerializeField] private Color pickWithMouseColor = Color.blue;

        [Header("Unit")]
        [SerializeField] private GameObject unitPrefab;
        [SerializeField] private Transform unitParent;
        private List<Unit> allUnits = new List<Unit>();

        [Header("Spawn Options")]
        [SerializeField] private int randomCount = 1;
        [SerializeField] private bool spawnRandomOnStart = false;
        [SerializeField] private float mouseRange = 5f;
        [SerializeField] private int numberOfUnitsAtOneTimeWithMouse = 5;

        [Header("QuadTree Options")]
        [SerializeField] private float x = 0f;
        [SerializeField] private float y = 0f;
        [SerializeField] private float width = 20f;
        [SerializeField] private float height = 20f;
        [SerializeField] private int capacity = 4;
        private QuadTree<Unit> quadTree;

        [Header("Handle Melee")]
        [SerializeField] private bool useQuadTreeForHandleMelee = true;

        #endregion

        #region Unity Lifecycle

        private void Start()
        {
            Rectangle boundry = new Rectangle(x, y, width, height);
            quadTree = new QuadTree<Unit>(boundry, capacity);

            if (!spawnRandomOnStart) return;

            for (int i = 0; i < randomCount; i++)
            {
                float randomX = Random.Range(-width, width);
                float randomZ = Random.Range(-height, height);
                Vector3 randomPosition = new Vector3(randomX, 1f, randomZ);

                GenerateNewUnit(randomPosition);
            }
        }

        private void Update()
        {
            quadTree.ClearAllNodes();
            allUnits.ForEach(unit =>
            {
                unit.Move(quadTree, Time.deltaTime);
                quadTree.Insert(unit);
            });
            quadTree.ShowBoundries();

            if (useQuadTreeForHandleMelee)
                HandleMeleeWithQuadTree();
            else
                HandleMelee();

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PickUnits(mousePosition, mouseRange);

            GenerateNewUnitWithMouse(numberOfUnitsAtOneTimeWithMouse, 2f);
        }

        #endregion

        #region Helpers

        public void GenerateNewUnitWithMouse(int count, float range)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetButtonDown("Fire1"))
            {
                for (int i = 0; i < count; i++)
                {
                    float randomX = Random.Range(mousePosition.x - range, mousePosition.x + range);
                    float randomZ = Random.Range(mousePosition.z - range, mousePosition.z + range); // Unity's y axis is up and z axis depth. So we use z axis instead y axis for Vector3
                    Vector3 randomPosition = new Vector3(randomX, 1f, randomZ);

                    if (!quadTree.IsPositionValid(randomPosition.x, randomPosition.z)) return;
                    GenerateNewUnit(randomPosition);
                }
            }
        }

        public void PickUnits(Vector3 position, float range)
        {
            Rectangle pickBoundry = new Rectangle(position.x, position.z, range, range);

            ShowBoundries(pickBoundry);
            List<Unit> pickedUnits = quadTree.Query(pickBoundry);

            pickedUnits.ForEach(unit =>
            {
                unit.SetColor(pickWithMouseColor);
            });
        }


        private void GenerateNewUnit(Vector3 newPosition)
        {
            Unit unit = Instantiate(unitPrefab, newPosition, Quaternion.identity, unitParent).GetComponent<Unit>();
            allUnits.Add(unit);
            quadTree.Insert(unit);
        }

        #endregion

        #region Melee

        private void HandleMelee()
        {
            for (int a = 0; a < allUnits.Count; a++)
            {
                allUnits[a].SetColor(idleUnitColor);

                for (int b = 0; b < allUnits.Count; b++)
                {
                    bool isCollide = allUnits[a].IsCollide(allUnits[b]) ? true : false;
                    if (isCollide)
                    {
                        allUnits[a].SetColor(collidingUnitColor);
                    }
                }
            }
        }

        private void HandleMeleeWithQuadTree()
        {
            allUnits.ForEach(unit =>
            {
                unit.SetColor(idleUnitColor);

                List<Unit> inRangeUnits = quadTree.Query(unit.Circle);

                if (inRangeUnits.Count > 1)
                {
                    unit.SetColor(collidingUnitColor);
                }
            });
        }

        public void ShowBoundries(Rectangle boundry)
        {
            float x = boundry.centerX;
            float y = boundry.centerY;
            float w = boundry.halfOfWidth;
            float h = boundry.halfOfHeight;

            Vector3 nwCorner = new Vector3(x - w, 0, y + h);
            Vector3 neCorner = new Vector3(x + w, 0, y + h);
            Vector3 swCorner = new Vector3(x - w, 0, y - h);
            Vector3 seCorner = new Vector3(x + w, 0, y - h);

            Debug.DrawLine(nwCorner, neCorner, pickWithMouseColor);
            Debug.DrawLine(nwCorner, swCorner, pickWithMouseColor);
            Debug.DrawLine(neCorner, seCorner, pickWithMouseColor);
            Debug.DrawLine(swCorner, seCorner, pickWithMouseColor);
        }

        #endregion
    }
}

