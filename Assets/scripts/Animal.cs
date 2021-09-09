using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int vidas;
    [SerializeField] bool movingRight;
    float minX, maxX;
    int contador = 3;
    float tiempo = 5f;
    int copia;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        copia = vidas;
        
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempo -= Time.deltaTime;
        if (contador >= 1)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0.5f;
                vidas = 1;
            }
            if (tiempo <= 0)
            {
                Time.timeScale = 1f;
                contador--;
                tiempo = 5f;
                vidas = copia;
            }
            
        }
        
        if (movingRight)
        {
            Vector2 movimiento = new Vector2(Time.deltaTime * speed, 0);

            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(Time.deltaTime * -speed, 0);

            transform.Translate(movimiento);
        }
        //ACA VOY A VERIFICAR LA POSICION
        if (transform.position.x >= maxX)
        {
            movingRight = false;
        }
       else if (transform.position.x <= minX)
        {
            movingRight = true;
        }
        }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        if (etiqueta == "Disparo")
        {
            vidas--;
            if (vidas == 0)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).Numenemigos();
                Destroy(this.gameObject);
            }
        }
    }
}
