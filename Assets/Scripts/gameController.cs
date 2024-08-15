using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameController : MonoBehaviour
{

    //Variáveis de controle dos objetos
    [Header("Config. Level Design")]
    public float tamanhoLevel;
    public float distanciaDestruir;
    public float velocidadeLevel;
    public GameObject[] levelProfab;

    //Variáveis de pontuação
    [Header("Config. Pontuação")]
    public int score;
    public TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Função de pontuação
    public void pontuar (int _pontos)
    {
        score += _pontos;
        textScore.text = score.ToString();
    }

    //Função para mudar de cena
    public void mudarCena(string _cena)
    {
        SceneManager.LoadScene(_cena);
    }

    //Função para sair do jogo
    public void exitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
