using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public string sceneToUnload;
    public string sceneToLoad; 
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);

        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneToUnload);
    }
    
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title Screen [Start Here]");
    }
   
}
