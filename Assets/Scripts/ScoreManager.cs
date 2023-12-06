using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SamChauffe
{
    public class ScoreManager : MonoBehaviour
    {
        private static double _score = 0;
        public static double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;


        int score = 0;
        int highscore = 0;

        // Start is called before the first frame update
        void Start()
        {
            scoreText.text = "Votre score : " + score.ToString();
            highScoreText.text = "Meilleur score : " + highscore.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
