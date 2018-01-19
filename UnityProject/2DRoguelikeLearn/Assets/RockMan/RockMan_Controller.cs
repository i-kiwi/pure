using UnityEngine;
using System.Collections;

public class RockMan_Controller : MonoBehaviour
{
	Animator _anim;
	public float MoveSpeed = 5f;
	public float JumpPower = 400f;
    public bool isJump = false;
	private Rigidbody2D m_Rigidbody2D;
	//public Transform Shot_Point;
	//public GameObject rocket;
	//public ParticleSystem[] Smog;
	//bool Attck_ing;
	Vector3 Start_Scale;	

	void Start ()
	{
		_anim = GetComponent<Animator> ();
		Start_Scale = transform.localScale;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update ()
    {                                                       
        float xx = Input.GetAxisRaw("Horizontal");
        if (xx != 0) { 				
			transform.localScale = new Vector3 (Start_Scale.x * xx, Start_Scale.y, Start_Scale.z);
			transform.Translate (Vector3.right * xx * MoveSpeed * Time.deltaTime);
            _anim.SetBool("run", true);
		}else
        {
            _anim.SetBool("run", false);
        }

		//if Ironman do Jump.
		if (Input.GetKeyDown (KeyCode.Space) && !isJump) {
            isJump = true;
            m_Rigidbody2D.AddForce(new Vector2(0f, JumpPower));
            _anim.SetTrigger("jump");                                           //Play ShotAnimation.													//Prevant change state until Finish this Motion.
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("ground"))
        {
            isJump = false;
        }
    }
}
