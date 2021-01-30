using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    public Transform hit;
    public Camera thiscamera;
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public int counter = 0;
    public Material red;
    public Material yellow;
    private MeshRenderer Pt1;
    private MeshRenderer Pt2;
    private MeshRenderer Pt3;
    private MeshRenderer Pt4;
    public string  scoretext;
    public Text scoreBox;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
         Pt1 = point1.GetComponent<MeshRenderer>();
         Pt2 = point2.GetComponent<MeshRenderer>();
         Pt3 = point3.GetComponent<MeshRenderer>();
         Pt4 = point4.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = thiscamera.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.CompareTag("point1"))
                { target = hit.transform;
                    Pt1.material = red;
                    Pt2.material = yellow;
                    Pt3.material = yellow;
                    Pt4.material = yellow;
                }
                if (hit.transform.CompareTag("point2"))
                {
                    target = hit.transform;
                    Pt1.material = yellow;
                    Pt2.material = red;
                    Pt3.material = yellow;
                    Pt4.material = yellow;
                }
                if (hit.transform.CompareTag("point3"))
                {
                    target = hit.transform;
                    Pt1.material = yellow;
                    Pt2.material = yellow;
                    Pt3.material = red;
                    Pt4.material = yellow;
                }
                if (hit.transform.CompareTag("point4"))
                {
                    target = hit.transform;
                    Pt1.material = yellow;
                    Pt2.material = yellow;
                    Pt3.material = yellow;
                    Pt4.material = red;
                }
            }
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "point1" || other.tag == "point2" || other.tag == "point3" || other.tag == "point4")
        {
            counter++;
            scoretext = "Score: " + counter;
            scoreBox.text = scoretext; 
        }
    }
}
