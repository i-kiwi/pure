using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RockMan_Controller : NetworkBehaviour
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

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	void Start ()
	{
		_anim = GetComponent<Animator> ();
		Start_Scale = transform.localScale;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update ()
    {             
        //if(!isLocalPlayer){
        //    return;
        //}
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

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            _anim.SetBool("shoot", true);
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _anim.SetBool("shoot", false);
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
