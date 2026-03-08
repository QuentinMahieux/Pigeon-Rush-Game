using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public static PlayerHand instance;
    
    public Transform hand;
    public DefaultFood actualFood;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerHand in scene!");
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && actualFood)
        {
            actualFood.ThrowFood();
        }
    }
    
    public void TakeFood(VisualInterraction food, bool isStorage)
    {
        if (actualFood)
        {
            return;
        }

        if (isStorage)
        {
            GameObject newFoodGameObject = Instantiate(food.foodDataKeep.foodData.prefab, hand, true);
            VisualInterraction newFood = newFoodGameObject.GetComponent<VisualInterraction>();
            newFoodGameObject.transform.localPosition = Vector3.zero;
            
            newFood.foodDataKeep.boxCollider.enabled = false;
            PlayerHand.instance.actualFood = newFood.foodDataKeep;
        
            newFood.foodDataKeep.rb.linearVelocity = Vector3.zero;
            newFood.foodDataKeep.rb.angularVelocity = Vector3.zero;
            newFood.foodDataKeep.rb.useGravity = false;
            newFood.foodDataKeep.rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            food.gameObject.transform.SetParent(hand);
            food.gameObject.transform.localPosition = Vector3.zero;
            
            food.foodDataKeep.boxCollider.enabled = false;
            PlayerHand.instance.actualFood = food.foodDataKeep;
        
            food.foodDataKeep.rb.linearVelocity = Vector3.zero;
            food.foodDataKeep.rb.angularVelocity = Vector3.zero;
            food.foodDataKeep.rb.useGravity = false;
            food.foodDataKeep.rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        food.foodDataKeep.isTaking();



    }
}
