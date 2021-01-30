using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject centrePoint, enemy;

    private int countToSpawn, countToRandomNumGen, randomTimerGenerator;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 0.5f;
        countToSpawn = 0;
        countToRandomNumGen = 0;
        randomTimerGenerator = Random.Range(120, 600);
    }

    // Update is called once per frame
    void Update()
    {

        transform.RotateAround(centrePoint.transform.position, transform.up, rotateSpeed);

        countToRandomNumGen++;
        countToSpawn++;

        if (countToRandomNumGen >= 60)
        {
            randomTimerGenerator = Random.Range(120, 600);
            countToRandomNumGen = 0;
        }
        if (countToSpawn >= randomTimerGenerator)
        {
            countToSpawn = 0;
            Instantiate(enemy, transform.position, Quaternion.identity);
            if (rotateSpeed <= 22.4f)
            {
                rotateSpeed += 0.3f;
            }

        }
    }
}