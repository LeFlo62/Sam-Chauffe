using System.Collections;
using System.Collections.Generic;
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
        }
    }
}
