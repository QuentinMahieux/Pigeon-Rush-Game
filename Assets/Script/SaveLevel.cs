using System;
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
    public void SetString(String name, int value = 0)
    {
        if (!PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.SetInt(name, 0);
            Debug.Log("💾 " + name + " has been saved.");
        }
        Save();
    }
    
    //Regarde si le score et meilleur que l'ancien score
    public void NewScore(string name, int score)
    {
        if (score > PlayerPrefs.GetInt(name))
        {
            PlayerPrefs.SetInt(name, score);
            Debug.Log(name + " best score: "  + score);
        }
        Save();
    }
    public void NewInt(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
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
    public int GetInt(String name)
    {
        Debug.Log("Return Best score");
        return PlayerPrefs.GetInt(name);
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
    
    public void SetSaveFloat(string coordoneeName, float coordoneeFloat)
    {
        if (!PlayerPrefs.HasKey(coordoneeName))
        {
            PlayerPrefs.SetFloat(coordoneeName, coordoneeFloat);
        }
        Save();
    }
    
    public void NewFloat(string coordoneeName, float coordoneeFloat)
    {
        PlayerPrefs.SetFloat(coordoneeName, coordoneeFloat);
        Save();
    }
}
