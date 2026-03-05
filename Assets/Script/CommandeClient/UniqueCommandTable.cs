using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UniqueCommandTable : MonoBehaviour
{
    public Table actualTable;

    public Image icon;
    public TMP_Text tableNumber;
    public Slider sliderClientWaint;
    

    public bool InstantiateCommandTable(Table newTable)
    {
        if (actualTable)
        {
            return false;
        }
        
        actualTable = newTable;
        icon.sprite = actualTable.clientIcon.sprite;
        tableNumber.text = "N" + actualTable.tableNumber;
        
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
