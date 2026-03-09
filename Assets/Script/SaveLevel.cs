using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    public bool NoSave = false;
    public static  SaveLevel instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one SaveLevel in scene.");
            Destroy(gameObject);
        }
    }
    
    //Enregistre tout le niveau qui n'ont pas encore d'index
    public void SetSave(LevelData level)
    {
        if (!PlayerPrefs.HasKey(level.levelName))
        {
            PlayerPrefs.SetInt(level.levelName, 0);
            Debug.Log("💾 " + level.levelName + " has been saved.");
        }
        Save();
    }
    
    //Regarde si le score et meilleur que l'ancien score
    public void NewScore(int score, LevelData level)
    {
        if (score > PlayerPrefs.GetInt(level.levelName))
        {
            PlayerPrefs.SetInt(level.levelName, score);
            Debug.Log(level.levelName + " best score: "  + score);
        }
        Save();
    }

    //Sauvegarde les informations
    public void Save()
    {
        if (NoSave)
        {
            PlayerPrefs.DeleteAll();
        }
        PlayerPrefs.Save();
        Debug.Log("💾 Game saved.");
    }
    
    //Revoit le meillieux score pour un niveau
    public int GetBestScore(LevelData level)
    {
        Debug.Log("Return Best score");
        return PlayerPrefs.GetInt(level.levelName);
    }

    public void SetSaveCoordonne(string coordoneeName, float coordoneeFloat)
    {
        if (!PlayerPrefs.HasKey(coordoneeName))
        {
            PlayerPrefs.SetFloat(coordoneeName, coordoneeFloat);
        }
        else
        {
            NewCoordonee(coordoneeName, coordoneeFloat);
        }
        Save();
    }
    
    public void NewCoordonee(string coordoneeName, float coordoneeFloat)
    {
        PlayerPrefs.SetFloat(coordoneeName, coordoneeFloat);
        Save();
    }

    public float GetCoordonee(string coordoneeName)
    {
        Debug.Log("📥 Return Coordonee " + coordoneeName);
        return PlayerPrefs.GetFloat(coordoneeName);
    }
}
