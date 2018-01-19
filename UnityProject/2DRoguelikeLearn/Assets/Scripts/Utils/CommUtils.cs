using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommUtils{

	public static int getNextCode(string code)
	{
		return Mathf.Abs(code.GetHashCode());
	}
}
