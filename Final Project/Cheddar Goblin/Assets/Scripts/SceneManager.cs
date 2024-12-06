using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //public string sceneToUnload;
    public string sceneToLoad; 
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);

        //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneToUnload);
    }
   

    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title Screen [Start Here]");
    }

    public void CloseGame()
    {
        // Quit the application
        Application.Quit();

        // Stop playing the game in the Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #endif
    }

}
