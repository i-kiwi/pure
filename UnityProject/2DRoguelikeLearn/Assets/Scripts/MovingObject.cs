using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;
	public LayerMask blockingLayer;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
	private float inverseMoveTime;

    private bool isJump = false;
    private bool isDoubleJump = false;


	// Use this for initialization
    protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		rb2D = GetComponent<Rigidbody2D>();
		inverseMoveTime = 1f / moveTime;
	}
	
    protected bool Move(int xDir, float yDir)
    {
		Vector2 start = transform.position;
		Vector2 moveEnd = start + new Vector2(xDir, 0);

        //boxCollider.enabled = false;

        //hit = Physics2D.Linecast(start, end, blockingLayer);

        //boxCollider.enabled = true;

        //if(hit.transform == null)
        //{
        //StartCoroutine(SmoothMovement(end));
        SmoothMove(moveEnd);
        //Jump(jumpEnd);

        return true;
		//}
		//return false;
	}
    protected void SmoothMove(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        if (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            //rb2D.MovePosition();

            rb2D.MovePosition(newPosition);
        }
    }
    protected void Jump(float force)
    {
        //if (!isJump)
        //{
        //    Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
        //    //rb2D.MovePosition();

        //    rb2D.MovePosition(newPosition);
        //    isJump = true;
        //}
        if (!isJump)
        {
            rb2D.AddForce(new Vector2(0f, force));
            isJump = true;
        }
    }

	protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		while(sqrRemainingDistance > float.Epsilon)
		{
			Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            //rb2D.MovePosition();
			rb2D.MovePosition(newPosition);

            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
		}
	}

    protected virtual void AttempMove (int xDir, float yDir)
		{
			bool canMove = Move(xDir, yDir);
		}

    //protected abstract void OnCantMove <T> (T component)
    //where T : Component;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            isJump = false;
            isDoubleJump = false;
        }
    }
}
