using System.Collections.Generic;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
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
    
    void SetSaveAllLevel(List<LevelData> allLevels)
    {
        foreach (LevelData level in allLevels)
        {
            if (!PlayerPrefs.HasKey(level.levelName))
            {
                PlayerPrefs.
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
