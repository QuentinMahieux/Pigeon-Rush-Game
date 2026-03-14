using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    public float range = 5f;
    public Material OutLineMaterial;
    
    [SerializeField] private VisualInterraction lastInteraction;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one PlayerInteraction in scene");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(GameManager.instance.isPause) return;
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range) && !PlayerHand.instance.actualFood)
        {
            if (hit.transform.gameObject.CompareTag("Interactable"))
            {
                Debug.Log("Interactable");
                VisualInterraction newInteraction = hit.transform.gameObject.GetComponent<VisualInterraction>();
                if (newInteraction != lastInteraction && lastInteraction)
                {
                    lastInteraction.DesactiveOutLine();
                }
                lastInteraction = newInteraction;
                lastInteraction.ActiveOutLine();

                string foodName = null;
                foreach (StringTranslate translate in lastInteraction.foodDataKeep.foodData.name)
                {
                    if (translate.language == GameManager.instance.language)
                    {
                        foodName = translate.text;

                    }
                }
                
                TextManager.instance.AddText(foodName);


                if (Input.GetMouseButtonDown(0))
                {
                    PlayerHand.instance.TakeFood(lastInteraction, lastInteraction.isStorage);
                    //lastInteraction.DesactiveFood();
                }
            }
            else if (lastInteraction)
            {
                lastInteraction.DesactiveOutLine();
                TextManager.instance.AddText(" ");

                lastInteraction = null;
            }
        }
        else if  (lastInteraction)
        {
            lastInteraction.DesactiveOutLine();
            TextManager.instance.AddText(" ");

            lastInteraction = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
}
