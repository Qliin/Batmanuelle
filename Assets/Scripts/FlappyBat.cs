using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBat : MonoBehaviour 
{
	private Rigidbody2D b_rigidbody;
	private BatInput b_input;
	public GameObject gameManager;
	private float jumpForce = 6f;
	// Use this for initialization
	void Start () 
	{
		b_rigidbody = GetComponent<Rigidbody2D>();
		b_input = GetComponent<BatInput>();
		gameManager = GameObject.FindWithTag("GM");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(b_input.jump && Time.timeScale == 1)
		{
			b_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//GameOver
		gameManager.SendMessage("OnGameOver");
	}
}
