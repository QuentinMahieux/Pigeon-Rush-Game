using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public List<ClientData> clients;
    
    [Header("Time Settings")]
    [Range(0, 500)]
    public int timerLevel = 300;
    [Tooltip("Intervale de temps entre le spawn de 2 client")] 
    public int timeIntervalClient = 25;
}
