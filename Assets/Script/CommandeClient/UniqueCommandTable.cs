using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UniqueCommandTable : MonoBehaviour
{
    [SerializeField] private Table actualTable;

    public Image icon;
    public TMP_Text tableNumber;
    public Slider sliderClientWaint;
    

    public void InstantiateCommandTable(Table newTable)
    {
        actualTable = newTable;
        icon.sprite = actualTable.clientIcon.sprite;
        tableNumber.text = "N" + actualTable.tableNumber;
        sliderClientWaint.value = actualTable.sliderWaiting.value;
        
    }
}
