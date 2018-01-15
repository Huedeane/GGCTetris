using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    float fall = 0;
    public float fallspeed = 1;

    public bool allowRotation = true;
    public bool limitRotation = false;

    // Use this for initialization
    void Start()
    {
        Debug.Log("startShapeHasBeenCalled");
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();
    }
    void CheckUserInput()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position += new Vector3(1, 0, 0);
            if (CheckIsValidPosition())
            {
                FindObjectOfType<game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.position += new Vector3(-1, 0, 0);
            if (CheckIsValidPosition())
            {
                FindObjectOfType<game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (allowRotation)
            {
                if (limitRotation)
                {
                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                        if (CheckIsValidPosition())
                        {
                            FindObjectOfType<game>().UpdateGrid(this);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                        if (CheckIsValidPosition())
                        {
                            FindObjectOfType<game>().UpdateGrid(this);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                }
                else
                {


                    transform.Rotate(0, 0, 90);
                    if (CheckIsValidPosition())
                    {
                        FindObjectOfType<game>().UpdateGrid(this);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallspeed)
        {

            transform.position += new Vector3(0, -1, 0);
            if (CheckIsValidPosition())
            {
                FindObjectOfType<game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<game>().DeleteRow();

                enabled = false;

                FindObjectOfType<game>().SpawnNextShape();
            }


            fall = Time.time;
        }
    }
    bool CheckIsValidPosition()
    {
        foreach (Transform mino in transform)
        {
            Vector2 pos = FindObjectOfType<game>().Round(mino.position);

            if (FindObjectOfType<game>().CheckIsInsideGrid(pos) == false)
            {
                return false;
            }
            if (FindObjectOfType<game>().GetTransformAtGridPosition(pos) != null && FindObjectOfType<game>().GetTransformAtGridPosition(pos).parent != transform)
            {
                return false;
            }
        }
        return true;
    }
}
