using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    //Vari�veis do level Design
    private gameController _gameController;
    private Rigidbody2D levelDRb;
    private bool instanciado;

    // Start is called before the first frame update
    void Start()
    {
        //Acessando o script geral
        //Acessando o rigidbody dos obstaculos do jogo e da plataforma
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
        levelDRb = GetComponent<Rigidbody2D>();

        //Aplicando velocidade nos objetos e na plataforma
        levelDRb.velocity = new Vector2(_gameController.velocidadeLevel, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Instanciando novos objetos
        //Acessando a posi��o x dos objetos
        float posX = transform.position.x;

        //Se instanciado for falso
        if(!instanciado) 
        {
            //Se a posi��o dos objetos for menor igual a zero
            if(posX <= 0)
            {
                //Impedindo a cria��o de novas instancias
                instanciado = true;

                //Indice para sele��o dos profabs
                int levelProfab = 0;
                //Sorteio
                int rand = Random.Range(0, 100);

                //Sorteando os tipos de leveis com base no sorteio.
                if(rand >= 75)
                {
                    levelProfab = 0;
                }
                else if(rand >= 50)
                {
                    levelProfab = 1;
                }
                else if(rand >= 25)
                {
                    levelProfab = 2;
                }
                else 
                {
                    levelProfab = 3;
                }

                //Instanciando novos objetos
                GameObject newLevel = Instantiate(_gameController.levelProfab[levelProfab]);
                float newposX = transform.position.x + _gameController.tamanhoLevel;
                float newposY = transform.position.y;
                newLevel.transform.position = new Vector3(newposX, newposY, 0);
            }
        }

        //Destruindo os objetos ao sairem da room
        if(posX <= _gameController.distanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
