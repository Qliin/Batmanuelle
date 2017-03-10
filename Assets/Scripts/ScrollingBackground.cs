using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour 
{
	private float scrollSpeed = 0.01f;
	private Material bg_material;

	void Start () 
	{
		bg_material = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float offset = Mathf.Repeat(Time.time * scrollSpeed, 1);
		bg_material.mainTextureOffset = new Vector2(offset, 0);
	}
}
