using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : MonoBehaviour
{
	public float moveSpeed = 3f;
	public float rotSpeed = 100f;

	private bool isWandering = false;
	private bool isRotatingLeft = false;
	private bool isRotatingRight = false;
	private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		if(isWandering == false)
		{
			StartCoroutine(Wander());
		}
		if(isRotatingRight == true)
		{
			transform.Rotate(transform.up * rotSpeed *Time.deltaTime);
		}
		if(isRotatingLeft == true)
		{
			transform.Rotate(transform.up *rotSpeed * Time.deltaTime);
		}
		if(isWalking == true)
		{
			transform.position += (transform.forward * moveSpeed * Time.deltaTime);
		}
    }

	IEnumerator Wander()
	{
		int rotTime = Random.Range(1, 3);      //time it takes to rotate//
		int rotateWait = Random.Range(1, 4);   // time between ech rotatation//
		int rotateLorR = Random.Range(0, 3); // turning left or right//
		int walkWait = Random.Range(1, 4);    // time between each walk cycle//
		int walkTime = Random.Range(1, 5);  //amount of time it can walk in one go//

		isWandering = true;

		yield return new WaitForSeconds(walkWait);      
		isWalking = true;

		yield return new WaitForSeconds(walkTime);
		isWalking = false;

		yield return new WaitForSeconds(rotateWait);
		if(rotateLorR == 1)
		{
			isRotatingRight = true;
			yield return new WaitForSeconds(rotTime);
			isRotatingRight = false;
		}
		if(rotateLorR == 2)
		{
			isRotatingLeft = true;
			yield return new WaitForSeconds(rotTime);
			isRotatingLeft = false;
		}
		isWandering = false; // repeating the whole process//
	}
}
