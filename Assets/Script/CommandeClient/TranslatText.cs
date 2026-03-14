using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslatText : MonoBehaviour
{
    public List<StringTranslate> stringTranslate;
    public TMP_Text text;
    void Update()
    {
        foreach (StringTranslate st in stringTranslate)
        {
            if (GameManager.instance.language.id == st.language.id)
            {
                text.text = st.text;
            }
        }
    }
}
