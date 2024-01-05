using System.Collections;
using System.Collections.Generic;
using SamChauffe;
using UnityEngine;

public class TutorialFire : Fire
{
    public DoorControler door;
   public void Extinguish()
    {
        base.Extinguish();
        door.openDoor();
    }
}
