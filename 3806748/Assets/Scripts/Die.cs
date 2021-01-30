using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject PS;
    public AudioClip AC;

    public float[] Damage = { 3, 1, 0.5f, 0 };

    [SerializeField] private string[] AcceptedCollisionTags;
    private AudioSource AS;
    private bool IsDelayedDeath = false;

    private void Start()
    { 
        AS = gameObject.GetComponent<AudioSource>();

        if (AS == null)
        {
            AS = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
    }

    private void Update()
    {
        if (IsDelayedDeath)
        {
            if (!AS.isPlaying)
            {
                FinalDie();
            }
        }
    }


    public void DoDie()
    {
        if (PS != null)
        {
            Instantiate(PS, transform.position, transform.rotation );
        }

        if (AS != null)
        {
            IsDelayedDeath = true;

            AS.PlayOneShot(AC);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            FinalDie();
        }
    }

    private void FinalDie()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string _tag in AcceptedCollisionTags) 
        {
            if (collision.gameObject.tag == _tag)
            {
                Health temp = collision.gameObject.GetComponent<Health>();
                temp.DoDamage(Damage[temp.ArmourType]);
                DoDie();
            } 
        }
    }
}
