using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Information")] 
    public string levelName = "L0-0";
    
    [Header("Client Settings")]
    public List<ClientData> clients;
    [Tooltip("Intervale de temps entre le spawn de 2 client")] 
    public float timeIntervalClient = 25;
    public float waitTimeClient = 10.5f;
    
    [Header("Time Settings")]
    [Range(0, 500)]
    public int timerLevel = 180;

    [Header("Star")] 
    public int[] starsPallier = new int[3];
}
