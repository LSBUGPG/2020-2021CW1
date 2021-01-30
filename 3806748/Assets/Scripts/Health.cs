using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHP = 10;
    public int ArmourType = 0;

    private Die Death;
    private string[] ArmourTypes = { "air_light", "air_med", "air_high", "player" };

    private void Start()
    {
        Death = gameObject.GetComponent<Die>();
    }

    public void DoDamage(float Damage)
    {
        MaxHP -= Damage;

        if(MaxHP <= 0)
        {
            Death.DoDie();
        }
    }
}
