using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamChauffe
{
    public class SceneChanger : MonoBehaviour
    {
        public int sceneId;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Cursor.lockState = CursorLockMode.None;
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
            }
        }
    }
}
