using UnityEngine;

[CreateAssetMenu(fileName = "LanguageData", menuName = "Scriptable Objects/LanguageData")]
public class LanguageData : ScriptableObject
{
	public int id;
    public string name;
    public Sprite flag;
}

[System.Serializable]
public class StringTranslate
{
    public string text;
    public LanguageData language;
}
