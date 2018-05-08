using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleManCtrl : MonoBehaviour {

    const float moveTime = 5;
    float inverseMoveTime;
    Animator animator;
    bool canMove;

    // Use this for initialization
    void Start() {
        this.animator = this.GetComponent<Animator>();
        canMove = true;
        Debug.Log((byte)3);
    }

    // Update is called once per frame
    void Update() {
        if (canMove)
        {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[tag]" + collision.tag);
        if (collision.tag == "wall")
        {
            canMove = false;
        }
    }
}
