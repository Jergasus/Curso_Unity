using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image barra;
    public void ActualizaVida(float hp, float max_hp)
    {
        barra.fillAmount = hp / max_hp;
    }
}
