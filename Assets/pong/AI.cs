using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	public float force = 5;
	private GameObject ball;
	RaycastHit2D ballCollision;
	ContactFilter2D filter = new ContactFilter2D();
	RaycastHit2D ballCollision2;
	ContactFilter2D filter2 = new ContactFilter2D();
	// Use this for initialization
	void Start() {
		filter.layerMask = 1 << LayerMask.NameToLayer("SideWall");
		filter2.layerMask = 1 << LayerMask.NameToLayer("RayDetector");
		ball = GameObject.Find("Ball");
	}

	// Update is called once per frame
	void Update() {
		float speed = -GetComponent<Rigidbody2D>().position.y;
		if (ball.GetComponent<Rigidbody2D>().velocity.x < 0) {
			if (speed > 2) {
				speed = 2f;
			} else if(speed < -2) {
				speed = -2f;
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().position.x, speed);
		}

		ballCollision = Physics2D.Raycast(ball.transform.position, ball.GetComponent<Rigidbody2D>().velocity, Mathf.Infinity, filter.layerMask);
		ballCollision2 = Physics2D.Raycast(ball.transform.position, ball.GetComponent<Rigidbody2D>().velocity, Mathf.Infinity, filter2.layerMask);
		Debug.Log(ballCollision.collider);
		if (ballCollision.collider != null) {
			Vector2 velocity = ball.GetComponent<Rigidbody2D>().velocity;
			ballCollision = Physics2D.Raycast(ballCollision.point, new Vector2(velocity.x, -velocity.y), filter.layerMask);
		}
		if (ballCollision2.collider != null) {
			if (ballCollision2.collider.name == "AIPaddle") {
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				return;
			}
			if (Mathf.Abs(GetComponent<Rigidbody2D>().position.y - ballCollision2.point.y) > .6) {
				speed = GetComponent<Rigidbody2D>().position.y - ballCollision2.point.y;
				if (speed > 2) {
					speed = 2f;
				} else if (speed < -2) {
					speed = -2f;
				}
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().position.x, -speed);
			}
		}




	}
}
