using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleManCtrl : MonoBehaviour {

    const float moveTime = 5;
    float inverseMoveTime;
    Animator animator;

    // Use this for initialization
    void Start() {
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        int horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        int vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
            this.transform.localScale = new Vector3(horizontal, 1, 1);
        if (horizontal != 0 || vertical != 0)
        {
            inverseMoveTime = horizontal * vertical != 0 ? Mathf.Sqrt(moveTime * moveTime / 2) : moveTime;
            this.transform.Translate(new Vector3(horizontal * inverseMoveTime * Time.deltaTime, vertical * inverseMoveTime * Time.deltaTime, 0));
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }
}
