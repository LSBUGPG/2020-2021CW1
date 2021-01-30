using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public GameObject[] plants;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    
    int randPlant;
     
 

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(Spawner());

    }

   

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
    }


    IEnumerator Spawner()
    {
        yield return new WaitForSeconds (startWait);

        while (!stop)
        {
            randPlant = Random.Range (0,3);

            Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x),1, Random.Range (-spawnValues.z, spawnValues.z));
            


            GameObject NewPlant = (GameObject) Instantiate (plants[randPlant], spawnPosition, gameObject.transform.rotation);
            Follow AI = (Follow) Object.FindObjectOfType (typeof(Follow));
            AI.goal = NewPlant.transform;

            yield return new WaitForSeconds (spawnWait);
        }

    }


}