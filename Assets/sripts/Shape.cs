using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckUserInput ();
	}
    void CheckUserInput () {

        if (Input.GetKeyDown(KeyCode.RightArrow)) {

            transform.position += new Vector3(1, 0, 0);

        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            transform.position += new Vector3(-1, 0, 0);
                
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {


        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {

           transform.position += new Vector3(0, -1, 0);

        }
    }
}
