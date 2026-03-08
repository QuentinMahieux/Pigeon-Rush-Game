using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public LevelData levelData;
    public GameObject allTable;
    public List<Table> tableLibres;

    [Header("Time")] 
    public float actualTime;
    public TMP_Text timeText;
    
    [Header("Score")]
    public int actualScore;
    public TMP_Text scoreText;
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

        actualScore = 0;
        scoreText.text = actualScore.ToString();
        
        //Ajoute un nombre de client part defaut
        for (int i = 0; i < levelData.numberDefaultClient; i++)
        {
            AddClientToTable();
        }
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime >= levelData.timerLevel)
        {
            ScoreManager.instance.AfficheScores(actualScore, levelData);
        }
        int remaining = (int)(levelData.timerLevel - actualTime);
        int minutes = remaining / 60;
        int seconds = remaining % 60;

        timeText.text = minutes.ToString() + ":" + seconds.ToString("D2");
    }

    IEnumerator SpawnTable()
    {
        while (actualTime <= levelData.timerLevel)
        {
            yield return new WaitForSeconds(levelData.courbeClientSpawn.Evaluate(actualTime));
            AddClientToTable();
        }
    }

    void AddClientToTable()
    {
        if (tableLibres.Count > 0)
        {
            tableLibres[Random.Range(0, tableLibres.Count)].AddClient(levelData.clients[Random.Range(0, levelData.clients.Count)]);
        }
    }

    public void AddScore(int score)
    {
        actualScore += score;
        scoreText.text = actualScore.ToString();
    }
    
    public void QuitLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}
