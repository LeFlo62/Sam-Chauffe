using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SamChauffe
{
    public class ScoreManager : MonoBehaviour
    {
        public static double score;

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;

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
}
