using UnityEngine;
using System.Collections;

public class RockMan_Controller : MonoBehaviour
{
	Animator _anim;
	public float MoveSpeed = 5f;
	public float JumpPower = 400f;
	private Rigidbody2D m_Rigidbody2D;
	//public Transform Shot_Point;
	//public GameObject rocket;
	//public ParticleSystem[] Smog;
	//bool Attck_ing;
	Vector3 Start_Scale;

    bool isJump = false;
    bool isDoubleJump = false;

	void Start ()
	{
		_anim = GetComponent<Animator> ();
		Start_Scale = transform.localScale;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{ 		
		//if RockMan move to Left or Right.
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) { 				
																			//First ,you can check to Ironman isn't Attacking
			_anim.SetBool("Move", true);																	//Change to MoveState, and Play Move Animation.
			float xx = Input.GetAxisRaw ("Horizontal"); 													//Read InputDirection.				
            transform.localScale = new Vector3 (Start_Scale.x * xx, Start_Scale.y, Start_Scale.z);
		    transform.Translate (Vector3.right * xx * MoveSpeed * Time.deltaTime);
				
		}else{
			_anim.SetBool("Move", false);              														//if Ironman don't move, Change Idle State.
		}

		//if Ironman do Jump.
        if (Input.GetKeyDown (KeyCode.Space) && !isJump) {
            //isJump = true;
			m_Rigidbody2D.AddForce(new Vector2(0f, JumpPower));
            _anim.SetTrigger("Jump");	
		}
		//if Ironman do Shoot.
        if (Input.GetMouseButtonDown(3)){	
			//m_Rigidbody2D.AddForce(new Vector2(0f, JumpPower));
            _anim.SetBool("Fire", true);
        } 
        if (Input.GetMouseButtonUp(3)){ 
            _anim.SetBool("Fire", false);
        }
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Ground")
    //    {
    //        isJump = false;
    //        //isDoubleJump = false;
    //        _anim.SetBool("Jump", false);    
    //    }
    //}
}
