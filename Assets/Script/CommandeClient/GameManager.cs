using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public LevelData levelSelect;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one GameManager in scene.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }

    public void StartLevel()
    {
        LevelData newlevelSelect = MetroController.instance.actualStation.levelData;
        levelSelect = newlevelSelect;

        MetroController.instance.SetCoordonee();
        
        SceneManager.LoadScene(newlevelSelect.levelName);
    }

    void OnApplicationQuit()
    {
        if (MetroController.instance)
        {
            MetroController.instance.SetCoordonee();
        }
    }
}
