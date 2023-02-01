using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida_Coleccionable : MonoBehaviour
{
    public Image heart;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActualizaVida(float hp, float max_hp)
    {
        heart.fillAmount = hp / max_hp;
    }
}
