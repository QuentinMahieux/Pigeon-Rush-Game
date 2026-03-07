using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    public string tableNumber;
    public ClientData actualClientData;
    public GameObject commandDontListen;

    [Header("Waiting")]
    public Slider sliderWaiting;

    private float remainingTime = 0f;
    private bool isWaiting = false;

    [Header("End Repas")] 
    public Transform spawnPlateSale;
    public float timeForEat = 2.5f;
    public FoodData plateSale;
    public GameObject interfaceGameObject;
    
    [Header("Visual elements")] 
    public TMP_Text textNumberTable;
    public Image clientIcon;

    public void InstanciateTable(int newTableNumber)
    {
        isWaiting = false;
        tableNumber = newTableNumber.ToString();
        if (tableNumber.Length < 10)
        {
            tableNumber = "0" + tableNumber;
        }
        textNumberTable.text = tableNumber;
        commandDontListen.SetActive(false);
        interfaceGameObject.SetActive(false);
    }
    
    void LateUpdate()
    {
        if (remainingTime > 0 && isWaiting)
        {
            remainingTime -= Time.deltaTime;

            sliderWaiting.value = remainingTime / LevelManager.instance.levelData.waitTimeClient;
        }
        else if (remainingTime <= 0 && isWaiting)
        {
            RemoveClient();
        }
    }

    public void AddClient(ClientData newClientData)
    {
        actualClientData = newClientData;
        clientIcon.sprite = actualClientData.icon;
        remainingTime = LevelManager.instance.levelData.waitTimeClient;
        isWaiting = true;
        
        LevelManager.instance.tableLibres.Remove(this);
        commandDontListen.SetActive(true);
        interfaceGameObject.SetActive(true);
        CommandeManager.instance.AddCommande(this);
        Debug.Log("Client Added table:  " + tableNumber + " recipe: "+ actualClientData.name);
    }

    public void EatClient()
    {
        isWaiting = false;
        interfaceGameObject.SetActive(false);
        LevelManager.instance.AddScore(actualClientData.score);

        
    }

    public void RemoveClient(int score = 0)
    {
        actualClientData = null;
        commandDontListen.SetActive(false);
        LevelManager.instance.tableLibres.Add(this);
        CommandeManager.instance.RemoveCommande(this);
        
        isWaiting = false;

        if (score > 0)
        {
            Instantiate(plateSale.prefab, spawnPlateSale.position, spawnPlateSale.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable") && actualClientData != null)
        {
            PlateFood plateFood = collision.gameObject.GetComponent<PlateFood>();
            if (plateFood != null && plateFood.actualClientData.id == actualClientData.id)
            {
                StartCoroutine(TimeToEat(timeForEat, plateFood));
            }
        }
    }

    IEnumerator TimeToEat(float time, PlateFood plateFood)
    {
        plateFood.transform.parent = spawnPlateSale;
        plateFood.transform.localPosition = Vector3.zero;
        plateFood.transform.localRotation = Quaternion.identity;
        plateFood.rb.linearVelocity = Vector3.zero;
        plateFood.rb.constraints = RigidbodyConstraints.FreezeRotation;
        plateFood.rb.useGravity = false;
        plateFood.boxCollider.enabled = false;
        
        EatClient();
        yield return new WaitForSeconds(time);
        plateFood.gameObject.SetActive(false);
        RemoveClient(actualClientData.score);
    }
    
}
