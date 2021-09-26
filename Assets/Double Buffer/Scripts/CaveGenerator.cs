using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.DoubleBuffer
{
    [RequireComponent(typeof(MeshRenderer))]
    internal class CaveGenerator : MonoBehaviour
    {
        #region Fields

        [Header("Display cave")]
        private MeshRenderer caveDisplayRenderer;

        [Header("Grid")]
        [SerializeField] private int gridSize = 100;
        private int[,] bufferOld;
        private int[,] bufferNew;

        [Header("Randomize Options")]
        [Range(0, 100)]
        [SerializeField] private float randomFillPercent;
        [SerializeField] private string seed;
        [SerializeField] private bool useSeed;


        [Header("Smooth Options")]
        [SerializeField] private int smoothSteps = 20;
        [SerializeField] private float pauseTime = 1f;

        [Header("Smooth Coroutine")]
        private Coroutine smoothCoroutine = null;
        private bool isSmoothCoroutineRun = false;

        #endregion

        #region Unity Lifecycle Methods

        private void Start()
        {
            caveDisplayRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1")) //new cave
            {
                if (smoothCoroutine != null && isSmoothCoroutineRun == true)
                {
                    StopCoroutine(smoothCoroutine);
                    isSmoothCoroutineRun = false;
                }

                GenerateEmptyCave();
                RandomFillCave();
                DisplayCave(bufferOld);
            }
            else if (Input.GetButtonDown("Fire2")) //smooth cave
            {
                if (smoothCoroutine == null || isSmoothCoroutineRun == false)
                    smoothCoroutine = StartCoroutine(SmoothCave());
            }
        }

        #endregion

        #region Cave Generation and Display Methods

        private void GenerateEmptyCave()
        {
            bufferOld = new int[gridSize, gridSize];
            bufferNew = new int[gridSize, gridSize];
        }

        private void RandomFillCave()
        {
            if (useSeed)
            {
                Random.InitState(seed.GetHashCode());
            }
            bufferOld = ArrayManipulator.Manipulate(bufferOld, GetRandomCellValue);
        }

        private void DisplayCave(int[,] data)
        {
            Resources.UnloadUnusedAssets();

            Texture2D texture = new Texture2D(gridSize, gridSize);
            texture.filterMode = FilterMode.Point;

            Color[] textureColors = new Color[gridSize * gridSize];
            textureColors = ArrayManipulator.ManipulateFrom2DTo1D<Color, int>(textureColors, data, GetTextureFromValue);

            texture.SetPixels(textureColors);
            texture.Apply();

            caveDisplayRenderer.sharedMaterial.mainTexture = texture;
        }

        #endregion

        #region Cellular Automata Methods

        private IEnumerator SmoothCave()
        {
            isSmoothCoroutineRun = true;

            for (int i = 0; i < smoothSteps; i++)
            {
                RunCellularAutomataStep();

                DisplayCave(bufferNew);

                (bufferOld, bufferNew) = (bufferNew, bufferOld);

                yield return new WaitForSeconds(pauseTime);
            }

            isSmoothCoroutineRun = false;
            Debug.Log("Simulation completed");
        }

        private void RunCellularAutomataStep()
        {
            bufferNew = ArrayManipulator.ManipulateFromAnother(bufferNew, bufferOld, CellularAutomataCellProcess);
        }

        private int GetSurroundingWallCount(int cellX, int cellY)
        {
            int wallCount = 0;

            for (int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX++)
            {
                for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++)
                {
                    if (neighborX == cellX && neighborY == cellY)
                    {
                        continue;
                    }

                    if (bufferOld[neighborX, neighborY] == 1)
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        #endregion

        #region Cell Processes

        private int GetRandomCellValue(int cellValue, int cellX, int cellY)
        {
            if (cellX == 0 || cellX == gridSize - 1 || cellY == 0 || cellY == gridSize - 1)
            {
                cellValue = 1;
            }
            else
            {
                cellValue = Random.Range(0f, 100f) < randomFillPercent ? 1 : 0;
            }
            return cellValue;
        }

        private Color GetTextureFromValue(Color cellValue, int fromCellValue, int cellX, int cellY)
        {
            cellValue = fromCellValue == 1 ? Color.black : Color.white;
            return cellValue;
        }

        private int CellularAutomataCellProcess(int cellValue, int fromCellValue, int cellX, int cellY)
        {
            if (cellX == 0 || cellX == gridSize - 1 || cellY == 0 || cellY == gridSize - 1)
            {
                return 1;
            }

            int surroundingWalls = GetSurroundingWallCount(cellX, cellY);
            if (surroundingWalls > 4)
            {
                return 1;
            }
            else if (surroundingWalls == 4)
            {
                return fromCellValue;
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}

