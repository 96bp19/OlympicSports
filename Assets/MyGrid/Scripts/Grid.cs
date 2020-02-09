using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public Grid (int width, int height , float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for (int w = 0; w < gridArray.GetLength(0); w++)
        {
            for (int h = 0; h < gridArray.GetLength(1); h++)
            {

            }
        }

    }

    Vector3 getWorldPos(int width , int height)
    {
        return new Vector3(width, height) * cellSize;
    }
}
