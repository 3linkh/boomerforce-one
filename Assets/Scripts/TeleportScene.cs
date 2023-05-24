using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TeleportScene : MonoBehaviour
{
    public int sceneIndex;  // The build index of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider entered belongs to the player or any other desired object
        if (other.CompareTag("Portal"))
        {
            // Change the scene to the specified scene index
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

