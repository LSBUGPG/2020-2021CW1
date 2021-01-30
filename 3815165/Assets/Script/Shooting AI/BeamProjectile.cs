using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectile : BaseProjectile
{
    public float beamLength = 10.0f;
    GameObject m_launcher;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (m_launcher)
        {
            GetComponent<LineRenderer>().SetPosition(0, m_launcher.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, m_launcher.transform.position + (m_launcher.transform.forward * beamLength));
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage)
    {
        if (launcher)
        {
           m_launcher = launcher;
            transform.SetParent(m_launcher.transform);
        }
    }
}
