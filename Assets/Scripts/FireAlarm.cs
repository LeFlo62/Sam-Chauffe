using UnityEngine;

namespace SamChauffe
{
    public class FireAlarm : Interactable
    {
        public AudioSource audioSource;

        public override void Interact()
        {
            if (!GlobalVariables.isAlarmRinging)
            {
                ScoreManager.score += 100;
                audioSource.Play();
                GlobalVariables.isAlarmRinging = true;
            }
        }
    }
}
