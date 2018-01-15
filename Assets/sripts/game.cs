using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{

    public static int gridwidth = 10;
    public static int gridheight = 20;
    public static Transform[,] grid = new Transform[gridwidth, gridheight];
    // Use this for initialization
    void Start()
    {
        Debug.Log("startstart");
        SpawnNextShape();
        Debug.Log("startend");
    }
    public bool IsFullRowAt(int y)
    {
        for (int x = 0; x < gridwidth; ++x)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }
    public void DeleteMinoAt(int y)
    {
        for (int x = 0; x < gridwidth; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }
    public void MoveRowDown(int y)
    {
        for (int x = 0; x < gridwidth; ++x)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0); 
            }
        }
    }
    public void MoveAllRowsDown(int y)
    {
        for (int i = y; i < gridheight; ++i)
        {
            MoveRowDown(i);
        }
    }
    public void DeleteRow()
    {
        for (int y = 0; y < gridheight; ++y)
        {
            if (IsFullRowAt(y))
            {
                DeleteMinoAt(y);
                MoveAllRowsDown(y + 1);
                --y;
            }
        }
    }
    public void UpdateGrid(Shape shape)
    {
        for (int y = 0; y < gridheight; ++y)
        {
            for (int x = 0; x < gridwidth; ++x)
            {
                if (grid[x, y] != null)
                {
                    if (grid[x, y].parent == shape.transform)
                    {
                        grid[x, y] = null;

                    }
                }
            }
        }
        foreach (Transform mino in shape.transform)
        {
            Vector2 pos = Round(mino.position);
            if (pos.y < gridheight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }
    public Transform GetTransformAtGridPosition(Vector2 pos)
    {
        if (pos.y > gridheight - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }
    public void SpawnNextShape()
    {
        Debug.Log("nextshapewillbecalled");
        GameObject nextShape = (GameObject)Instantiate(Resources.Load(GetRandomShape(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }
    public bool CheckIsInsideGrid(Vector2 pos)
    {

        return ((int)pos.x >= 0 && (int)pos.x < gridwidth && (int)pos.y >= 0);
    }
    public Vector2 Round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
    string GetRandomShape()
    {
        int randomShape = Random.Range(1, 8);
        string randomShapeName = "prefabs/Shape_T";
        switch (randomShape)
        {
            case 1:
                randomShapeName = "prefabs/Shape_T";
                break;
            case 2:
                randomShapeName = "prefabs/Shape_J";
                break;
            case 3:
                randomShapeName = "prefabs/Shape_L";
                break;
            case 4:
                randomShapeName = "prefabs/Shape_Long";
                break;
            case 5:
                randomShapeName = "prefabs/Shape_S";
                break;
            case 6:
                randomShapeName = "prefabs/Shape_Square";
                break;
            case 7:
                randomShapeName = "prefabs/Shape_Z";
                break;
        }
        return randomShapeName;
    }

}