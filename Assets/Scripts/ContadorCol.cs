using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorCol : MonoBehaviour
{
    public TMP_Text text;

    void Update()
    {
        text.text = TotalLife.hearts.ToString() + "/3";
    }

}
