using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
 
    public void moveToScene(int  sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }


}
