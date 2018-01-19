using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < 5; x++)
		{
			for (int y = 0; y < 5; y++)
			{
				if(x == 0 || y == 0 || x == 4 || y ==4)
				Instantiate(cube, new Vector3(x, y, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
