using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraDevidaEProgresao : MonoBehaviour
{
    public static float vidaDoPlayer = 100.0f;
    public Slider BarraDeVida;
    public Slider BarraDeProgrecao;
    public GameObject scripts;

    void Update()
    {
        if (vidaDoPlayer <= 0)
        {
            vidaDoPlayer = 0.0f;
            scripts.GetComponent<acoes>().PerdeuPartida();
        }
        BarraDeProgrecao.value = solo.kmPercorrido;
        BarraDeVida.value = vidaDoPlayer;
    }
}
