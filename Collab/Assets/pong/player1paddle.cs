using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxis("Vertical") * 2);
       
    }
}
