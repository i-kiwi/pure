using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyIntEvent : UnityEvent<int>
{

}

public class TT : MonoBehaviour {

    private MyIntEvent myIntEvent;

	// Use this for initialization
	void Start () {
        if (myIntEvent == null)
            myIntEvent = new MyIntEvent();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Ping()
    {
        Debug.Log("hhaha");
    }
}
