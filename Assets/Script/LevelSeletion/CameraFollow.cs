using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    public GameObject mainCamera;
    public CinemachineCamera cinemachineCamera;

    [Header("Interface")] 
    public TMP_Text nameLevel;
    public Image imageLevel;
    public TMP_Text bestScore;
    public TMP_Text nextScore;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one Camera Follower in the scene");
            Destroy(gameObject);
        }
        
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartFollow(Transform target, LevelData levelData)
    {
        mainCamera.gameObject.SetActive(false);
        cinemachineCamera.Follow = target;
        
        RefreshInterface(levelData);
    }

    public void StopFollow()
    {
        mainCamera.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void PressStartButton()
    {
        GameManager.instance.StartLevel();
    }
    
    void RefreshInterface(LevelData levelData)
    {
        nameLevel.text = levelData.levelName;
        imageLevel.sprite = levelData.sprite;
        

        bestScore.text = SaveLevel.instance.GetInt(levelData.levelName).ToString();

        nextScore.gameObject.SetActive(false);
        foreach (int pallier in levelData.starsPallier)
        {
            if (SaveLevel.instance.GetInt(levelData.levelName) <= pallier)
            {
                nextScore.gameObject.SetActive(true);
                nextScore.text = pallier.ToString();
                break;
            }
        }
    }
}
