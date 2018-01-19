using UnityEngine;
using System.Collections;

public class Player : MovingObject
{
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

        if (horizontal != 0)
        {
            //Call AttemptMove passing in the generic parameter Wall, since that is what Player may interact with if they encounter one (by attacking it)
            //Pass in horizontal and vertical as parameters to specify the direction to move Player in.
            AttempMove<Player>(horizontal, 0);
        }
	}

    //AttemptMove overrides the AttemptMove function in the base class MovingObject
    //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
    protected override void AttempMove<T>(int xDir, int yDir)
    {
        //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
        base.AttempMove<T>(xDir, yDir);
    }
}
