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
            scoreText.text = "Votre score : " + score.ToString();
            highScoreText.text = "Meilleur score : " + highscore.ToString();
        }
    }
}
