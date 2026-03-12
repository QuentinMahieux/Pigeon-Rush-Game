using UnityEngine;
using UnityEngine.UI;

public class UniqueElementRecipe : MonoBehaviour
{
    public Image icon;
    public Image background;


    public void Affiche(Sprite sprite, bool active = true)
    {
        icon.enabled = active;
        background.enabled = active;
        icon.sprite = sprite;
    }
}
