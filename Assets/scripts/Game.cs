using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static int gridWidth =10;
	public static int gridHeight= 20;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CheckIsInsideGrid(Vector2 Pos)
	{
		return (int)Pos.x >=0 && (int)Pos.x < gridWidth && (int)Pos.y >= 0;
	}

	public Vector2 Round (Vector2 pos)
	{
		return new Vector2 (Mathf.Round (pos.x), Mathf.Round (pos.y));
	}
}
