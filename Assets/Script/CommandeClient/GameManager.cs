using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public LevelData levelSelect;
    
    
    
    [Header("Pause")]
    public bool isPause;
    
    [Header("Settings")]
    [Header("Language")]
    public LanguageData language;
    public List<LanguageData> languageList;

    [Header("Performance")] 
    public int currentFPS = 60;
    
    [Header("Audio")] 
    public float audioVolume = 0.5f;

    [Header("Senssibilty")] 
    public float senssibility = 2.5f;
    
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
        Application.targetFrameRate = currentFPS;
    }

    void Start()
    {
        //Language
        if (language)
        {
            SaveLevel.instance.SetString("languageSetting", language.id);
        }
        int languageId = SaveLevel.instance.GetInt("languageSetting");
        foreach (LanguageData l in languageList)
        {
            if (l.id == languageId)
            {
                language = l;
            }
        }
        
        //Audio
        SaveLevel.instance.SetSaveFloat("AudioSetting", audioVolume);
        AudioMananger.instance.PlayAudio(AudioMananger.instance.audioSeletLevel);
        ChangeAudio(SaveLevel.instance.GetCoordonee("AudioSetting"));
        
        //Cursor
        SaveLevel.instance.SetSaveFloat("SensibilitySetting", senssibility);
        ChangeSenssibilty(SaveLevel.instance.GetCoordonee("SensibilitySetting"));
    }

    public void StartLevel()
    {
        LevelData newlevelSelect = MetroController.instance.actualStation.levelData;
        levelSelect = newlevelSelect;

        AudioMananger.instance.PlayAudio(AudioMananger.instance.audioGame);
        
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

    public void ChangeLanguage(LanguageData newLanguage)
    {
        language = newLanguage;
        SaveLevel.instance.NewInt( "languageSetting", language.id);
    }

    public void ChangeAudio(float volume)
    {
        AudioMananger.instance.ChangeVolume(volume);
        SaveLevel.instance.NewFloat("AudioSetting", volume);
    }
    
    public void ChangeSenssibilty(float newSenssibility)
    {
        SaveLevel.instance.NewFloat("SensibilitySetting", newSenssibility);
        senssibility = SaveLevel.instance.GetCoordonee("SensibilitySetting");
    }
}
