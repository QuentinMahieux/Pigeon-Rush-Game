using System;
using UnityEngine;

public class FoodCuite : DefaultFood
{
    [Header("Cooking Food")] 
    public string tagTransformator = "Baking Tray";
    public GameObject newFoodPrefab;

    public float timeToHot;
    public float actualTimeToHot;
    [SerializeField] private bool isCooking;

    void OnEnable()
    {
        isCooking = false;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag(tagTransformator))
        {
            isCooking = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (isCooking && !other.gameObject.CompareTag(tagTransformator))
        {
            isCooking = false;
        }
    }

    void Update()
    {
        if (!isCooking)
        {
            return;
        }
        actualTimeToHot += Time.deltaTime;
        if (actualTimeToHot > timeToHot)
        { 
            Instantiate(newFoodPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        
    }
}
