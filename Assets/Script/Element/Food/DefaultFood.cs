using UnityEngine;

public class DefaultFood : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public FoodData foodData;
    
    private bool inPlate = false;
    
    protected virtual void Start()
    {
        if (PlayerHand.instance == null)
        {
            return;
        }
        if (gameObject.transform.IsChildOf(PlayerHand.instance.hand))
        {
            boxCollider.enabled = false;
            PlayerHand.instance.actualFood = this;
        
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void ThrowFood()
    {
        transform.SetParent(null);
        PlayerHand.instance.actualFood = null;

        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        
        boxCollider.enabled = true;
        
        rb.AddForce(FirstPersonCamera.instance.transform.forward * (speed + PlayerController.instance.actualSpeed),  ForceMode.Impulse);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if (collision.gameObject.CompareTag("Interactable"))
        {
            PlateFood plateFood = collision.gameObject.GetComponent<PlateFood>();
            if (plateFood != null)
            {
                for (int i = 0; i < plateFood.compatibleFoods.Count; i++)
                {
                    if (foodData == plateFood.compatibleFoods[i].ingredient 
                        && plateFood.compatibleFoods[i].actualNumberIngredient < plateFood.compatibleFoods[i].numberIngredient)
                    {
                        plateFood.compatibleFoods[i].actualNumberIngredient++;
                        plateFood.NewFoodAdd();
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
