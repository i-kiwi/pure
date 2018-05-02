using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.IO;
using System.Text;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count{
		public int minimum;
		public int maximum;

		public Count(int min, int max){
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	public Count wallCount = new Count(5,9);
	public Count foodCount = new Count(1,5);
    public Count groundCount = new Count(100, 1000);
    public GameObject groundObject;
	public GameObject exit;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();

	public void SetupScene(int level)
	{
		BoardSetup();
	}


	Hashtable map = new Hashtable();
	void BoardSetup()
	{
        groundObject = new GameObject();
        System.Random random = new System.Random(Time.time.GetHashCode());
        for (int i = -groundCount.minimum; i < groundCount.minimum; i++)
        {
            Vector3 position = new Vector3(i, 0, 0);
            Instantiate(floorTiles[random.Next(floorTiles.Length)], groundObject.transform.position + position, Quaternion.identity, gameObject.transform);
        }
        // int length = 10;
		// for (int i = -10; i < length; i++)
		// {
		// 	Debug.Log("hello unity");
		// 	Vector3 position = new Vector3(i, 0, 0);
		// 	Instantiate(outerWallTiles[Random.Range(0, outerWallTiles.Length - 1)], position, Quaternion.identity);
		// }
	}

}

[Serializable]
public class Kiwi{
	private string name {get; set;}
	private int age {get; set;}

	public Kiwi(string _name, int _age){
		this.name = _name;
		this.age = _age;
	}

	override
	public string ToString(){
		return this.name;
	}

}
