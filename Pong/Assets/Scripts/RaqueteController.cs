using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{

   private Vector3 minhaPosicao;
    private float meuY ;

    public float limite= 3.5f;

    public bool player;

    public float speed;

    //Variavel para saber se ele vai ser controlado pela inteligencia artificial
    public bool automatico = false;

    //Pegando a posição da bola
    public Transform transformBola;

    // Start is called before the first frame update
    void Start()
    {
        //posição inicial da Raquete
        minhaPosicao.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Velocidade multiplicada pelo deltaTime

        float deltavelocidade = speed * Time.deltaTime;

      
       //Passando o meuY para o eixo Y da minhaPosicao
       minhaPosicao.y = meuY;

       //Modificar a posição de minha raquete
        transform.position = minhaPosicao;

          //Se o meu automatico NÄ é true
        if (!automatico)
        {
       //Pegando a setinha para cima
       // Se eu apertar a setinha para cima, a raquete sobe
       if (player)
       {
            if (Input.GetKey(KeyCode.UpArrow) )
       {     
            //aumentar o Valor do meuY APENAS SE ele for menor do que meu limite
             meuY = meuY + deltavelocidade;
        }

       // Pegando a setinha para baixo e conferindo se ele pode descer 
       if (Input.GetKey(KeyCode.DownArrow))
       {
            //Diminuir o Valor do meuY APENAS SE ele for maior do que meu limite
             meuY = meuY - deltavelocidade;
         
        }

        }

     else
    
       {

                //Meu codigo para colocar ele no automatico
                if(Input.GetKeyDown(KeyCode.Return))
                {
                  automatico = true;
                }

                if (Input.GetKey(KeyCode.W) )
                {
                //aumentar o Valor do meuY APENAS SE ele for menor do que meu limite
                meuY = meuY + deltavelocidade;
                }
        

                // Pegando a setinha para baixo e conferindo se ele pode descer 
                 if (Input.GetKey(KeyCode.S) )
                {
                 //Diminuir o Valor do meuY APENAS SE ele for maior do que meu limite
                  meuY = meuY - deltavelocidade;
                 }
     
      
        }

  
   

    }
       else
     {
       //Tirando ele do automatico
       //Checando se a seta para cima ou para baixo foi pressionada
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            automatico = false;
        }
       

       //se a raquete esta no automatico
        //Para acessar funções matemáticas, nós usamos a classe Mathf
      meuY = Mathf.Lerp(meuY,transformBola.position.y, 0.05f);

     }
    
       //Impedir que o bagulho suba
        if ( meuY > limite)
        {
            meuY = limite;
        }

     //Impedir que o bagulho desca
        if ( meuY < -limite)
        {
            meuY = -limite;
        }
    
    }
}
