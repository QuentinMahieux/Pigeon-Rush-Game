using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Scriptable Objects/FoodData")]
public class FoodData : ScriptableObject
{
    public StringTranslate[] name;
    public Sprite sprite;
    
    public GameObject prefab;
}
