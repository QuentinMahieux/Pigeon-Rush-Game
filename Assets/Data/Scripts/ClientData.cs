using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClientData", menuName = "Scriptable Objects/ClientData")]
public class ClientData : ScriptableObject
{
    public int id;
    public Sprite icon;
    public List<Ingredient> ingredientType;

    public int score;
}
