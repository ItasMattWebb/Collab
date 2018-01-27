using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    public float startingVelocity = 10;
	// Use this for initialization
	void Start () {
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(((Random.value >= 0.5) ? transform.right : -transform.right)* startingVelocity);


            }
	
	// Update is called once per frame
	void Update () {
		
	}
}
