using UnityEngine;

public class Package : DefaultFood
{
    [Header("Package Settings")]

    public int numberElementSpawn;
    public FoodData elementToSpawn;
    private bool isDestroyed = false;
    public string tagElementToDestroy = "Rock";
    

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        
        float numberToInstantiate = numberElementSpawn;
        VisualInterraction elementReInstanciate = null;
        if (collision.gameObject.CompareTag(tagElementToDestroy) && !isDestroyed)
        {
            isDestroyed = true;
            for (int i = 0; i < numberToInstantiate; i++)
            {
                GameObject foodPrefab = Instantiate(elementToSpawn.prefab, Vector3.zero ,Quaternion.identity);
                foodPrefab.transform.localPosition = transform.position;
                
                Rigidbody rbInstance = foodPrefab.GetComponent<Rigidbody>();
                Vector3 randomDirection = Random.onUnitSphere;
                rbInstance.AddForce(randomDirection * 1.9f, ForceMode.Impulse);
            }
            Destroy(gameObject);
        }
    }
}
