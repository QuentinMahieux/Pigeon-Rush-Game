using System.Collections.Generic;
using UnityEngine;

public class CommandeManager : MonoBehaviour
{
    public static CommandeManager instance;
    
    public List<Table> commandeTables;
    public GameObject allUniqueCommande;
    [SerializeField] private List<UniqueCommandTable> uniqueCommandTables = new List<UniqueCommandTable>();
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("More than one instance of CommandeManager");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        uniqueCommandTables.Clear();
        foreach (UniqueCommandTable table in allUniqueCommande.GetComponentsInChildren<UniqueCommandTable>())
        {
            uniqueCommandTables.Add(table);
            uniqueCommandTables[^1].gameObject.SetActive(false);
        }
    }

    public void AddCommande(Table newTable)
    {
        commandeTables.Add(newTable);
        uniqueCommandTables[commandeTables.Count].gameObject.SetActive(true);
        uniqueCommandTables[commandeTables.Count].InstantiateCommandTable(commandeTables[^1]);
    }
}
