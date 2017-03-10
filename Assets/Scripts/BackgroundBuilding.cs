using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBuilding : MonoBehaviour 
{
	private Rigidbody2D bu_rigidbody;
	private float velocity = 2;
	private Vector3[] childsPosition = new Vector3[2];

	// Use this for initialization
	void Start () 
	{
		bu_rigidbody = GetComponent<Rigidbody2D>();

		int index = 0;
		foreach(Transform child in transform)
		{
			childsPosition[index] = child.position;
			index++;
		}
	}

	void FixedUpdate()
	{
		bu_rigidbody.velocity = new Vector2(-velocity, 0);
	}

	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x < childsPosition[0].x)
		{
			velocity = Random.Range(1.5f, 2.5f);
			transform.position = childsPosition[1];
		}
	}
}
