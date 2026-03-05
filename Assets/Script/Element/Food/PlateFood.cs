using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlateFood : DefaultFood
{
    [Header("Plate Food")]
    public List<Ingredient> compatibleFoods;
    public List<Recipe> listFoodToRecipe;
    public Recipe actualRecipe;
    

    protected override void Start()
    {
        base.Start();
        foreach (var food in listFoodToRecipe)
        {
            food.foodPrefab.SetActive(false);
        }
    }

    public void NewFoodAdd()
    {
        for (int i = 0; i < listFoodToRecipe.Count; i++)
        {
            listFoodToRecipe[i].foodPrefab.SetActive(RecipeCheck(listFoodToRecipe[i]));
            actualRecipe  = listFoodToRecipe[i];
        }
    }

    public bool RecipeCheck(Recipe recipe)
    {
        return recipe.ingredientType.All(requireIngrendint =>
        {
            var PlateIngredient = compatibleFoods.FirstOrDefault(i => requireIngrendint.ingredient == i.ingredient);
            return (PlateIngredient != null && 
                    PlateIngredient.actualNumberIngredient == requireIngrendint.numberIngredient);
        });
    }
}
[Serializable]
public class Recipe
{
    public List<Ingredient> ingredientType;
    public GameObject foodPrefab;
}

[Serializable]
public class Ingredient
{
    public int numberIngredient;
    [HideInInspector] public int actualNumberIngredient;
    public FoodData ingredient;
}