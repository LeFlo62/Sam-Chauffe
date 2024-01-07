using System.Collections;
using System.Collections.Generic;
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
                audioSource.Play();
                GlobalVariables.isAlarmRinging = true;
            }
        }
    }
}
