using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;

    float minX, maxX, minY, maxY;
    float nextFire;
    [SerializeField] float fireRate1;
    [SerializeField] float fireRate2;
    
    public Transform FirePoint;
    public GameObject bullet;
    public GameObject bullet2;

    bool switchBullet = true;

    void Start()
    {
        new Vector2(1, 1);
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // Vector2 esquinaSupIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        Vector2 puntoMinParaY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));

        maxX = esquinaSupDer.x - 0.7f;
        maxY = esquinaSupDer.y - 0.7f;
        minX = puntoMinParaY.x + 0.7f;
        minY = puntoMinParaY.y;

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        if (switchBullet)
        {
            Disparar();
        }
        else
            DispararRa();

         if (Input.GetKeyDown(KeyCode.Z))
        {
            switchBullet = switchBullet ? false : true;
        }     
    }
    void MoverNave()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed);

        //ACA SE MUEVE

        transform.Translate(movimiento);

        //ACA VOY A VERIFICAR LA POSICION
        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)

        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }

    void Disparar()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bullet, FirePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate1;
        }
       
    }
    void DispararRa()
    {

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bullet2, FirePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate2;
        }

    }
}
