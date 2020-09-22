using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempo : MonoBehaviour
{

    public Text tempoUi;
    public float InicioText;
    public float tempoAtual;
    public bool fimTempo = false;
    public static bool PodeIniciarOTimer;

    void Start()
    {
        tempoAtual = 30.0f;
        tempoUi.text = "30.00";
        StartCoroutine(aguarda());
    }

    void Update()
    {
        if (PodeIniciarOTimer)
        {
            if (fimTempo)
                return;

            if (tempoAtual <= 0.01f)
            {
                tempoAtual = 0.0f;
                GetComponent<acoes>().PerdeuPartida();
            }
            else if (tempoAtual >= 0.01)
            {
                tempoAtual -= 1 * Time.deltaTime;
                tempoUi.text = tempoAtual.ToString("f2");
            }
        }
    }

    public void adicionarTempo(int tempo)
    {
        InicioText += tempo;
    }
    public void tirarTempo()
    {
        tempoAtual = 0.0f;
    }
    public IEnumerator aguarda()
    {
        yield return new WaitForSeconds(2.0f);
        PodeIniciarOTimer = true;

    }
}
