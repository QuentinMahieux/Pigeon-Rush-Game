using System;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    public GameObject mainCamera;
    public CinemachineCamera cinemachineCamera;

    [Header("Interface")] 
    public TMP_Text nameLevel;
    public TMP_Text bestScore;
    
    
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
        
        nameLevel.text = levelData.levelName;
        Debug.Log(levelData.levelName);
        bestScore.text = SaveLevel.instance.GetBestScore(levelData).ToString();
    }

    public void StopFollow()
    {
        mainCamera.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
