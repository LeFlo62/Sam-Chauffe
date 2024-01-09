using UnityEngine;
using UnityEngine.UI;

namespace SamChauffe
{
    public class HealthBarController : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int maxHealth) {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }

        public void UpdateHealth(int health)
        {
            slider.value = health;
            ScoreManager.score -= 30;
            Debug.Log(ScoreManager.score);
        }
    }
}
