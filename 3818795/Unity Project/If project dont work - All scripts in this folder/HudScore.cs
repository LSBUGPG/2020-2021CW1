using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudScore : MonoBehaviour
{
    public static int Score;
    public static int Score2;
    public int ScoreOverall;
    public Text ScoreUI;
    public static int Score3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
      
        Score = PointOverTime.score;

        Score2 = GatherCoins.Score;

        Score3 = PowerUpgivecoins.Score3;

        ScoreOverall = Score + Score2 + Score3;
        ScoreUI.text = "Score = " + ScoreOverall;
    }
}



