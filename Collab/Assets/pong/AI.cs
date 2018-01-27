using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    private GameObject ball;
    RaycastHit2D ballCollision;
    ContactFilter2D filter = new ContactFilter2D();
    RaycastHit2D ballCollision2;
    ContactFilter2D filter2 = new ContactFilter2D();
    // Use this for initialization
    void Start () {
        filter.layerMask = LayerMask.NameToLayer("sideWall");
        filter2.layerMask = LayerMask.NameToLayer("rayDectector");
        ball = GameObject.Find("ball");
    }
	
	// Update is called once per frame
	void Update () {
        ballCollision =Physics2D.Raycast(ball.transform.position, ball.GetComponent<Rigidbody2D>().velocity, Mathf.Infinity, filter.layerMask);
        ballCollision2 = Physics2D.Raycast(ball.transform.position, ball.GetComponent<Rigidbody2D>().velocity, Mathf.Infinity, filter2.layerMask);

        while (ballCollision.collider!= null)
        {
          /*  if (ballCollision2.collider!=null){
                break;
            }*/
            Vector2 velocity = ball.GetComponent<Rigidbody2D>().velocity;
            ballCollision = Physics2D.Raycast(ballCollision.point, new Vector2(velocity.x,-velocity.y), filter.layerMask);
        }
        /*if (ballCollision2.collider!=null)
        {
            Debug.Log(ballCollision2.collider);
            Vector2.MoveTowards(current: GetComponent<Rigidbody2D>().position, target: ballCollision2.point, maxDistanceDelta: 10f);
        }
        */


    }
}
