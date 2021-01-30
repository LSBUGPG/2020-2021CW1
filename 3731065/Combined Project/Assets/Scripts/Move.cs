using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

	public float speed = 2.0f;
	public float rotateSpeed = 5f;
	private Vector3 moveDirection = Vector3.zero;
	public AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       CharacterController controller = GetComponent<CharacterController>();

	  
	   moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
	   moveDirection = transform.TransformDirection(moveDirection);
	   moveDirection *= speed;
	 
	   controller.Move(moveDirection * Time.deltaTime);

	   transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }
	/*void OnTriggerEnter(Collider other)
	{
		if (other.tag == "plant")
		{
		
			if (pickUpSound)
			{
				AudioSource.PlayClipAtPoint (pickUpSound, transform.position);
			}
			Destroy(other.gameObject);
		}	
	}*/
}