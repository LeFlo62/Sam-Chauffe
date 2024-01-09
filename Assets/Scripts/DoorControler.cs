using UnityEngine;

public class DoorControler : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    private string doorOpen = "DoorOpen";

    public void openDoor() {
        Debug.Log("OUVERTURE");
        myDoor.Play(doorOpen, 0, 0.0f);
    }
}
