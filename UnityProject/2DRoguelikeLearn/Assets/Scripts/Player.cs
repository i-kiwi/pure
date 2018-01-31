using UnityEngine;
using System.Collections;

public class Player : MovingObject
{
    private float jumpForce = 500f;
    private float gravity = 5f;

	// Use this for initialization
    protected override void Start()
	{
        base.Start();
	}

	// Update is called once per frame
    private void Update()
	{
        int horizontal = 0;     //Used to store the horizontal move direction.
        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        int jump = (int)(Input.GetAxisRaw("Jump"));
        Debug.Log("[Jump]" + jump);
        if (horizontal != 0 || jump != 0)
        {
            if (horizontal > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }


            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            AttempMove(horizontal,jump * jumpForce);

            //if (vertical > 0)
            //{
            //    vertical -= gravity * Time.deltaTime;
            //}
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            base.Jump(jumpForce);											//Play ShotAnimation.													//Prevant change state until Finish this Motion.
        }

    }

    //AttemptMove overrides the AttemptMove function in the base class MovingObject
    //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
    protected override void AttempMove(int xDir, float yDir)
    {
        //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
        base.AttempMove(xDir, yDir);
    }
}
