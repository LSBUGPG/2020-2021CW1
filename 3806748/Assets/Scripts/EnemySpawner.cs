using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnTimerMax = 10f;
    private float SpawnTimerCurrent;

    [SerializeField] private GameObject[] EnemyTypes;
    [SerializeField] private float[] SpawnChance;

    private void Start()
    {
        SpawnTimerCurrent = Random.Range(0, SpawnTimerMax);
    }

    private void Update()
    {
        RepeatingSpawn();
    }

    private void RepeatingSpawn()
    {
        SpawnTimerCurrent += Time.deltaTime;

        if(SpawnTimerCurrent >= SpawnTimerMax)
        {
            SpawnTimerCurrent = 0;

            float PreviousChance = 0;
            int SpawnCurrent = 0;
            float TempChance;

            for (int i = 0; i < SpawnChance.Length; i++)
            {
                TempChance = Random.Range(0, SpawnChance[i]);

                if (TempChance > PreviousChance)
                {
                    PreviousChance = TempChance;
                    SpawnCurrent = i;
                }
            }

            Instantiate(EnemyTypes[SpawnCurrent], transform.position, transform.rotation);
        }
    }
}
