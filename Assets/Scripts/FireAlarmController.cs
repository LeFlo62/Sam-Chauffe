using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe
{
    public class FireAlarmController : MonoBehaviour
    {
        private AudioSource audioSource;

        public void launchAlarm()
        {
            if(!GlobalVariables.isAlarmRinging)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
                GlobalVariables.isAlarmRinging = true;
            }
        }
    }
}
