using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    
    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    #endregion

    public string winScene;
    public string loseScene;

    public void OnWin()
    {
        OnSceneChange();
        SceneManager.LoadScene(winScene);
    }

    public void OnLost()
    {
        OnSceneChange();
        SceneManager.LoadScene(loseScene);
    }

    public void OnSceneChange()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        OnSceneChange();
        SceneManager.LoadScene(sceneName);
    }
}
