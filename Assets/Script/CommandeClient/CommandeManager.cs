using System.Collections.Generic;
using UnityEngine;

public class CommandeManager : MonoBehaviour
{
    public static CommandeManager instance;
    
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
        for (int i = 0; i < uniqueCommandTables.Count; i++)
        {
            uniqueCommandTables[i].gameObject.SetActive(true);
            if (uniqueCommandTables[i].InstantiateCommandTable(newTable))
            {
                uniqueCommandTables[i].InstantiateCommandTable(newTable);
                return;
            }
            
        }
    }

    public void RemoveCommande(Table newTable)
    {
        for (int i = 0; i < uniqueCommandTables.Count; i++)
        {
            if (uniqueCommandTables[i].actualTable == newTable)
            {
                uniqueCommandTables[i].CloseCommand();
                return;
            }
        }
    }
}
