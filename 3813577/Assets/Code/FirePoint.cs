using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
public void Rotate()
	{
		transform.eulerAngles = new Vector3(0, 180, 0);
	}
	public void NoRotate()
	{
		transform.eulerAngles = new Vector3(0, 0, 0);
	}
}
