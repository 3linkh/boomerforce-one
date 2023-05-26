using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;  // The build index of the scene to load

    public void SwitchScene()
    {
        // Change the scene to the specified scene index
        SceneManager.LoadScene(sceneIndex);
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }
}
