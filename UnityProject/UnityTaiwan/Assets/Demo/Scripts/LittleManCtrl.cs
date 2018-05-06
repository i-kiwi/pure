using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleManCtrl : MonoBehaviour {

    public float inverseMoveTime = 5;
    private Rigidbody2D rb2D;


	// Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        int horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        if (horizontal != 0)
        {
            if (horizontal > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            this.transform.Translate(new Vector3(horizontal * inverseMoveTime * Time.deltaTime, 0, 0));
        }
        int vertical = (int)(Input.GetAxisRaw("Vertical"));
        if (vertical != 0) 
        {
            this.transform.Translate(new Vector3(0, vertical * inverseMoveTime * Time.deltaTime, 0));
        }

	}
}
