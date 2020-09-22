using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class acoes : MonoBehaviour
{

    public GameObject scripts;
    public GameObject ancora;
    public GameObject modalGanhou;
    public GameObject modalPerdeu;

    public Text vezesQueFurouOCinalGanhou;
    public Text VezesQueBateuGanhou;
    public Text lucroGanhou;
    public Text tempoGanhou;

    public Text vezesQueFurouOCinalPerdeu;
    public Text VezesQueBateuPerdeu;



    // Start is called before the first frame update
    void Start()
    {
        modalGanhou.SetActive(false);
        modalPerdeu.SetActive(false);

    }
    // o botão de relay da ui calcula este valor
    public void Replay()
    {
        solo.velocidadeFinal = 200.0f;
        solo.kmPercorrido = 0.0f;
        barraDevidaEProgresao.vidaDoPlayer = 100.0f;
        tempo.PodeIniciarOTimer = false;
        StartCoroutine(aguarda());
        SceneManager.LoadScene("render2");
    }

    // acionada no script "colisoesCarro"
    public void gangouPartida()
    {
        ancora.GetComponent<swipe>().terminouACorrida = 1;
        scripts.GetComponent<solo>().AcabouOJogo = true;
        solo.speed = 250.0f;
        scripts.GetComponent<tempo>().fimTempo = true;
        solo.velocidadeFinal = 250.0f;

        // preencher campos da ui de vitória
        vezesQueFurouOCinalGanhou.text = ancora.GetComponent<colisoesCarro>().quantasVezesPassouNoSemaforo.ToString();
        lucroGanhou.text = ancora.GetComponent<colisoesCarro>().lucro.ToString() + " R$";
        VezesQueBateuGanhou.text = ancora.GetComponent<colisoesCarro>().quantasVezesbateu.ToString();
        tempoGanhou.text = scripts.GetComponent<tempo>().tempoAtual.ToString("f2") + "s";

        // quando o game inicia ele zera o tempo e começa a contar novamente
        scripts.GetComponent<tempo>().tempoAtual = 0;

        ancora.GetComponent<Collider>().isTrigger = true;
        StartCoroutine(aguardaParaAbrirModalDeVitoria());
    }

    // acionada no script "tempo"
    public void PerdeuPartida()
    {
        ancora.GetComponent<swipe>().terminouACorrida = 2;
        scripts.GetComponent<solo>().AcabouOJogo = true;
        solo.speed = 0.0f;
        scripts.GetComponent<tempo>().fimTempo = true;
        solo.velocidadeFinal = 0.0f;

        // preencher campos da ui de derrota
        vezesQueFurouOCinalPerdeu.text = ancora.GetComponent<colisoesCarro>().quantasVezesPassouNoSemaforo.ToString();
        VezesQueBateuPerdeu.text = ancora.GetComponent<colisoesCarro>().quantasVezesbateu.ToString();

        // quando o game inicia ele zera o tempo e começa a contar novamente
        scripts.GetComponent<tempo>().tempoAtual = 0;
        ancora.GetComponent<Collider>().isTrigger = true;

        StartCoroutine(aguardaParaAbrirModalDerrota());
    }
    IEnumerator aguardaParaAbrirModalDeVitoria()
    {
        yield return new WaitForSeconds(1.0f);
        modalGanhou.SetActive(true);
    }
    IEnumerator aguardaParaAbrirModalDerrota()
    {
        yield return new WaitForSeconds(0.5f);
        modalPerdeu.SetActive(true);
    }

    public IEnumerator aguarda()
    {
        yield return new WaitForSeconds(2.0f);
        tempo.PodeIniciarOTimer = true;

    }



}
