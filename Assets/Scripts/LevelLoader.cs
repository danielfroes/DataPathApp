using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{       
    public static LevelLoader instance;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);    
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
