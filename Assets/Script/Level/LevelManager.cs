using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public LevelData levelData;
    public GameObject allTable;
    public List<Table> tableLibres;

    [Header("Time")] 
    public float actualTime;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one LevelManager in the scene");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        int index = 0;
        foreach (Table table in allTable.GetComponentsInChildren<Table>())
        {
            index++;
            tableLibres.Add(table);
            table.InstanciateTable(index);
        }
        StartCoroutine(SpawnTable());
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime >= levelData.timerLevel)
        {
            Debug.Log("Game Over");
        }
    }

    IEnumerator SpawnTable()
    {
        while (actualTime <= levelData.timerLevel)
        {
            yield return new WaitForSeconds(levelData.timeIntervalClient);
            if (tableLibres.Count > 0)
            {
                tableLibres[Random.Range(0, tableLibres.Count)].AddClient(levelData.clients[Random.Range(0, levelData.clients.Count)]);
            }
        }
    }
}
