using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    int score = 0;
    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " points";
        highScoreText.text = "Meilleur score : " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
