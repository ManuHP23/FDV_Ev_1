using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Movement : MonoBehaviour
{

    public bool canJump;
    public bool happy;
    public bool sad;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movemos al perro mediante físicas
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500 * Time.deltaTime, 0));
            
            //Para voltear el sprite según la dirección
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            //Condición para activar la animación de walking
            gameObject.GetComponent<Animator>().SetBool("walking", true);

        }

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500 * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("walking", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("walking", false);
        }

        if (Input.GetKeyDown("up") && canJump)
        {
            //El salto aplica una fuerza en un frame y no de forma continua
            //No hace falta el Time.deltaTime
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
            canJump = false;
        }
    }

    //Método para que solo salte una vez.
    //Detectamos cuando el collider del personaje se choca con el collider del suelo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }
    }

    //Método para las animaciones sad y happy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "bone")
        {
            gameObject.GetComponent<Animator>().SetBool("happy", true);
            gameObject.GetComponent<Animator>().SetBool("sad", false);
        }
        
        if (collision.transform.tag == "shit")
        {
            gameObject.GetComponent<Animator>().SetBool("sad", true);
            gameObject.GetComponent<Animator>().SetBool("happy", false);
        }
    }
}
