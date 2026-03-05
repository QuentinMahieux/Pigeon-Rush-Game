using System.Collections.Generic;
using UnityEngine;

public class MultipleVisualInterraction : VisualInterraction
{
    [Header("Multiple VisualInterraction Settings")]
    public List<VisualInterraction> listVisualInterractions;

    public override void ActiveOutLine()
    {
        base.ActiveOutLine();
        for (int i = 0; i < listVisualInterractions.Count; i++)
        {
            listVisualInterractions[i].ActiveOutLine();
        }
    }

    public override void DesactiveOutLine()
    {
        base.DesactiveOutLine();
        for (int i = 0; i < listVisualInterractions.Count; i++)
        {
            listVisualInterractions[i].DesactiveOutLine();
        }
    }
}
