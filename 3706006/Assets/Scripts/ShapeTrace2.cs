using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeTrace2 : MonoBehaviour
{
    public Transform[] MiniGames;
    public List<GameObject> corners;
    GameObject currentCorner;
    LineRenderer line;

    bool shapeComplete = false;
    int numberMG;
    int MGindex = 0;
    int numberOfCorners;

    // Start is called before the first frame update
    void Start()
    {
        corners = new List<GameObject>();
        line = GetComponent<LineRenderer>();
        numberMG = MiniGames.Length;
        numberOfCorners = MiniGames[MGindex].childCount;
    }

    public void AddCorner(GameObject G)
    {
        corners.Add(G);
    }

    // Update is called once per frame
    void Update()
    {
        if (shapeComplete == true)
        {
            return;
        }
        line.startWidth = 0.01f;
        line.endWidth = 0.01f;
        line.alignment = LineAlignment.TransformZ;
        line.positionCount = 1;

        line.positionCount = corners.Count;
 
        LineRenderer cc = GetComponent<LineRenderer>();
        cc.forceRenderingOff = false;
        cc.startWidth = 0.01f;
        cc.endWidth = 0.01f;
        cc.alignment = LineAlignment.TransformZ;
        cc.positionCount = 1;
        int c = corners.Count;
        if (corners.Count > 0)
        {
            cc.positionCount = corners.Count;

            if (corners.Count == numberOfCorners)
            {
                cc.positionCount += 1;
            }
            
            for (int i = 0; i < c; i++)
            {
                cc.SetPosition(i, corners[i].transform.position);
            }

            if (corners.Count == numberOfCorners)
            {

                if (corners.Count > 2)
                {
                    cc.SetPosition(numberOfCorners, corners[0].transform.position);
                }
                shapeComplete = true;
                Invoke("NextMiniGame", 2f);
            }
        }

    }

    void NextMiniGame()
    {
        corners = new List<GameObject>();
        line.forceRenderingOff = true;
        shapeComplete = false;
        MiniGames[MGindex].gameObject.SetActive(false);
        MGindex += 1;
        if (MGindex < MiniGames.Length)
        {
            MiniGames[MGindex].gameObject.SetActive(true);
            numberOfCorners = MiniGames[MGindex].childCount;
        }
    }
}
