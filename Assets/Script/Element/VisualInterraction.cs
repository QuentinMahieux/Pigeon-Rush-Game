using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class VisualInterraction : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private Material[] originalMaterials;
    private bool isGlow;
    
    [Header("Storage Settings")]
    [Tooltip("True: Infini, False: Récupére l'item")]
    public bool isStorage = false;
    public DefaultFood foodDataKeep;

    [Header("NPC Settings")] 
    public bool isNPC;
    public NPCManager npcManager;
    
    

    void Start()
    {
        originalMaterials =  meshRenderer.materials;
    }
    
    public virtual void ActiveOutLine()
    {
        if (isGlow) { return; }
        isGlow = true;
        
        Material[] curentMaterials = meshRenderer.materials;
        Material[] newMaterials = new Material[curentMaterials.Length + 1];
        for (int i = 0; i < curentMaterials.Length; i++)
        {
            newMaterials[i] = curentMaterials[i];
        }
        newMaterials[curentMaterials.Length] = PlayerInteraction.instance.OutLineMaterial;
        meshRenderer.materials = newMaterials;
    }

    public virtual void DesactiveOutLine()
    {
        isGlow = false;
        meshRenderer.materials = originalMaterials;
    }

    public void DesactiveFood()
    {
        gameObject.SetActive(false);
    }

    public void SpeakToNPC()
    {
        if (isNPC && npcManager)
        {
            npcManager.StartDialogue();
        }
    }
    
}
