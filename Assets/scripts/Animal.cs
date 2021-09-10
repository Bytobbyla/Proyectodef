using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed, activar;
    [SerializeField] int vidas;
    [SerializeField] bool movingRight;
    float minX, maxX, copiat, nextPower;
    int repetidor = 3;
    float tiempo = 50f;
    int copia;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        copia = vidas;
        copiat = tiempo;
        
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempo -= Time.deltaTime;
        poder();
        
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
    public void poder()
    {
        if (repetidor >= 1)
        {

            if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextPower)
            {
                nextPower = Time.time + activar;
                tiempo = 2.4f;
                Time.timeScale = 0.5f;
                vidas = 1;
            }
            if (tiempo <= 0)
            {
                Time.timeScale = 1f;
                tiempo = copiat;
                vidas = copia;
                repetidor--;
            }

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
