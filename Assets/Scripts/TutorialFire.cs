using UnityEngine;

namespace SamChauffe
{
    public class TutorialFire : Fire
    {

        public GameObject door;

        public override void Extinguish()
        {
            base.Extinguish();
            door.transform.rotation = Quaternion.Euler(0, 90, 0);
            //disable collision
            door.GetComponentInChildren<Collider>().enabled = false;
        }
    }
}
