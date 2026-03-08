using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StationMetro : MonoBehaviour
{
    public LevelData levelData;
    [Header("Other Destination")]
    public StationMetro D;
    public StationMetro Q;
    public StationMetro Z;
    public StationMetro S;
    
    [Header("Line Color")]
    public Renderer[] lineRenderer;
    public Material lineMaterial;
    
    [Header("Score")]
    public bool isWin;
    public Image[] stars = new Image[3];
    public Color starColor;
    
    void Start()
    {
        if (levelData)
        {
            SaveLevel.instance.SetSave(levelData);
            RestorSave();
        }
    }

    void Update()
    {
        if (isWin)
        {
            foreach (Renderer r in lineRenderer)
            {
                r.material = lineMaterial;
            }
        }
    }

    void RestorSave()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (levelData.starsPallier[i] <= SaveLevel.instance.GetBestScore(levelData))
            {
                stars[i].color = starColor;
                LevelWin();
            }
            else
            {
                return;
            }
        }
    }

    void LevelWin()
    {
        if (isWin)
        {
            return;
        }
        isWin = true;
        foreach (Renderer r in lineRenderer)
        { 
            r.material = lineMaterial;
        }
        
    }
}
