using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public string tableNumber;
    public ClientData actualClientData;

    [Header("Visual elements")] 
    public TMP_Text textNumberTable;
    public GameObject commandDontListen;
    public Image clientIcon;

    public void InstanciateTable(int newTableNumber)
    {
        tableNumber = newTableNumber.ToString();
        if (tableNumber.Length < 10)
        {
            tableNumber = "0" + tableNumber;
        }
        textNumberTable.text = tableNumber;
        commandDontListen.SetActive(false);
    }

    public void AddClient(ClientData newClientData)
    {
        actualClientData = newClientData;
        clientIcon.sprite = actualClientData.icon;
        
        LevelManager.instance.tableLibres.Remove(this);
        commandDontListen.SetActive(true);
        Debug.Log("Client Added table:  " + tableNumber + " recipe: "+ actualClientData.name);
    }

    public void RemoveClient(ClientData newClientData)
    {
        actualClientData = null;
        commandDontListen.SetActive(false);
        LevelManager.instance.tableLibres.Add(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable") && actualClientData != null)
        {
            PlateFood plateFood = collision.gameObject.GetComponent<PlateFood>();
            if (plateFood != null && plateFood.actualClientData.id == actualClientData.id)
            {
                plateFood.gameObject.SetActive(false);
                RemoveClient(actualClientData);
            }
        }
    }
}
