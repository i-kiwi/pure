using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameManager gameManager;
    public GameObject player;
	
	void Awake () {
		if(GameManager.instance == null)
			Instantiate(gameManager);
	}

    private void Update()
    {
        //this.transform.position = player.transform.position;
    }

}
