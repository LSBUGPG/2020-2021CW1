using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public float Counter;

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Counter = Counter + Time.deltaTime;

        if (Counter > 0.5)
		{
            Destroy(gameObject);
		}
    }
}
