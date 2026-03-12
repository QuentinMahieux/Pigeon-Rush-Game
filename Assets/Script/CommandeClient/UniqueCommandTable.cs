using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UniqueCommandTable : MonoBehaviour
{
    public Table actualTable;

    public Image icon;
    public TMP_Text tableNumber;
    public Slider sliderClientWaint;
    
    [Header("Recipe Element")]
    public GameObject allElementRecipe;
    public List<UniqueElementRecipe> allImageElements;

    void Start()
    {
        foreach (UniqueElementRecipe elementRecipe in allElementRecipe.GetComponentsInChildren<UniqueElementRecipe>())
        {
            allImageElements.Add(elementRecipe);
        }
    }

    public bool InstantiateCommandTable(Table newTable)
    {
        if (actualTable)
        {
            return false;
        }
        
        actualTable = newTable;
        icon.sprite = actualTable.clientIcon.sprite;
        tableNumber.text = "N" + actualTable.tableNumber;

        for (int i = 0; i < allImageElements.Count; i++)
        {
            allImageElements[i].Affiche(null, false);
        }
        
        List<Ingredient> ingredients = actualTable.actualClientData.ingredientType;
        int index = 0;
        for (int i = 0; i < ingredients.Count; i++)
        {
            if (ingredients[i].numberIngredient > 0)
            {
                for (int j = 0; j < ingredients[i].numberIngredient; j++)
                {
                    allImageElements[index].Affiche(ingredients[i].ingredient.sprite);
                    index++;
                }
            }
        }
        
        return true;
    }

    public void CloseCommand()
    {
        actualTable = null;
        gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        if (!actualTable)
        {
            return;
        }
        
        sliderClientWaint.value = actualTable.sliderWaiting.value;

    }
}
