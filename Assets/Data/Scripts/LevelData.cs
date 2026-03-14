using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Information")] 
    public string levelName = "L0-0";
    public Sprite sprite;
    
    [Header("Client Settings")]
    public List<ClientData> clients;
    public int numberDefaultClient = 1;
    [Tooltip("Courbe de l'intervale de temps en chaque apparisionde client, abscisse: Temps en seconde, ordonnée; temps d'attente entre 2 client ")] 
    public AnimationCurve courbeClientSpawn;
    public float waitTimeClient = 10.5f;
    
    [Header("Time Settings")]
    [Range(0, 500)]
    public int timerLevel = 180;

    [Header("Star")] 
    public int[] starsPallier = new int[3];
}
