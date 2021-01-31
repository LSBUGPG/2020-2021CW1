using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visuals : MonoBehaviour
{
    public float attackRange, sightRange;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
