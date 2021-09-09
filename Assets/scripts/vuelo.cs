using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vuelo : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public bool MoveToA = false;
    public bool MoveToB = false;
    public float speed;
    [SerializeField] int vidas;

    private Rigidbody2D MyRb;

    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MoveToB = true;
    }

    // Update is called once per frame
    void Update()
    {
     if(MoveToA)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, StartPoint.position, speed * Time.deltaTime);
            if(transform.position == StartPoint.position)
            {
                MoveToA = false;
                MoveToB = true;
            }
        }
        if (MoveToB)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, EndPoint.position, speed * Time.deltaTime);
            if (transform.position == EndPoint.position)
            {
                MoveToA = true;
                MoveToB = false;
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

