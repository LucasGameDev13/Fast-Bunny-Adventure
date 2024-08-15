using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Variáveis do player
    private gameController _gameController;
    private Rigidbody2D playerRb;
    public float forcaPulo;
    public Transform groundCheck;
    private bool grounded;
    public float limitePosX;
    

    // Start is called before the first frame update
    void Start()
    {
        //Acessando os componentes do Rigidbody
        playerRb = GetComponent<Rigidbody2D>();

        //Acessando o script do gamecontroller
        _gameController = FindObjectOfType(typeof(gameController)) as gameController;
    }

    private void FixedUpdate()
    {
        //Conferindo a colisão da variável groundcheck
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
       
    }

    // Update is called once per frame
    void Update()
    {
        //Aplicando a força do pulo
        //Se aperto espaço e estiver colidindo
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            //Aplico o pulo
            playerRb.AddForce(new Vector2(0, forcaPulo));
        }

        //Travando o player no lugar
        float posX = transform.position.x;

        if(posX <= limitePosX)
        {
            posX = limitePosX;
        }

        transform.position = new Vector2(posX,transform.position.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Garantindo as colisões dos itens coletaveis e dos obstaculos
        switch(collision.gameObject.tag) 
        {
            //Se coletavel, então ganho pontos
            case "coletavel":
                _gameController.pontuar(10);
                Destroy(collision.gameObject);
            break;
           //Se obstaculo, eu perco e vou pro gameover
            case "obstaculo":
                _gameController.mudarCena("GameOver");
            break;
        }
    }
}




    