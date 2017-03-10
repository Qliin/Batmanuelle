using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour 
{
	private Rigidbody2D w_rigidbody;
	private Transform spawner;
	private Transform leftBound;
	private float moveSpeed = 150f;

	void Awake () 
	{
		w_rigidbody = GetComponent<Rigidbody2D>();
		spawner = GameObject.FindWithTag("Spawner").transform;
		leftBound = GameObject.FindWithTag("BoundLeft").transform;
	}	

	void FixedUpdate () 
	{
		w_rigidbody.velocity = new Vector2(-moveSpeed * Time.deltaTime, 0);
	}

	void Update()
	{
		if(transform.position.x < leftBound.position.x)
		{
			ResetWall();
		}
	}

	void Initialize(Vector3 lane)
	{
		transform.position = lane;
		transform.rotation = Quaternion.identity;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{	
//		if(coll.gameObject.tag == "Player")
//		{
//			coll.gameObject.SendMessage("OnGameOver");
//			//gameManager.SendMessage("OnGameOver");
//		}

		if(coll.gameObject.tag != "Player")
		{
			ResetWall();
		}
	}

	void ResetWall()
	{
		transform.position = spawner.position;
		w_rigidbody.velocity = Vector2.zero;
		gameObject.SetActive(false);
	}
}
