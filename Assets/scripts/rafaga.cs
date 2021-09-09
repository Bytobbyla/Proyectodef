using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rafaga : MonoBehaviour
{
    private Rigidbody2D MyRb;
    public float speed2;
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyRb.velocity = new Vector2(0, -speed2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string etiqueta = objeto.tag;

        Destroy(this.gameObject);

    }
}
