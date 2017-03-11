using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject wallPrefab;

	private Transform[] spawnPoint = new Transform[2];

	private List<GameObject> wallPool = new List<GameObject>();
	private int initialPoolSize = 10;
 
	void Awake () 
	{
		int index = 0;
		foreach(Transform child in transform)
		{
			spawnPoint[index] = child;
			index++;
		}

		for(int i=0; i<initialPoolSize; i++)
		{
			CreateNewWall();
		}

		StartCoroutine(SpawnWalls());
	}

	IEnumerator SpawnWalls()
	{	
		float spawnOffset = Random.Range(-3, 3);

		foreach(Transform point in spawnPoint)
		{
			GameObject wall = GetWallFromPool();
			if(wall != null)
			{
				Vector3 pointWithOffset = new Vector3(point.position.x, point.position.y + spawnOffset, point.position.z);
				wall.SetActive(true);
				wall.SendMessage("Initialize", pointWithOffset);
			}
		}

		yield return new WaitForSeconds(1.5f);
		StartCoroutine(SpawnWalls());
	}

	GameObject GetWallFromPool()
	{
		foreach(GameObject asteroid in wallPool)
		{
			if(!asteroid.activeSelf)
			{
				return asteroid;
			}
		}

		//If there's no object in pool, create a new one.
		return CreateNewWall();
	}

	GameObject CreateNewWall()
	{
		GameObject newWall = Instantiate(wallPrefab, transform.position, Quaternion.identity);
		newWall.SetActive(false);
		wallPool.Add(newWall);

		return newWall;
	}
}
