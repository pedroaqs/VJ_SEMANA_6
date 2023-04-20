using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    bool live = true;
    // Start is called before the first frame update
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator animator;
    public GameObject bala; 
    // Estados del personaje
    const int DEAD = 100; 
    const int IDLE = 0; 
    const int RUN = 1;
    const int JUMP = 2;
    
    const int vStop = 0;
    const int vRun = 10;
    const int jumForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(live) {
            rb.velocity = new Vector2(vStop,rb.velocity.y);
            SetAnimacion(IDLE);

            
            if(Input.GetKey(KeyCode.RightArrow)) {
                Debug.Log("Correr derecha");
                sr.flipX = false ;
                rb.velocity = new Vector2(vRun,rb.velocity.y);
                SetAnimacion(RUN);
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                sr.flipX = true;
                rb.velocity = new Vector2(-vRun,rb.velocity.y);
                SetAnimacion(RUN);
            }

            if(Input.GetKeyDown(KeyCode.F)) {
                crearBala(vRun);
            }
            if(Input.GetKeyUp(KeyCode.Space)) {
                rb.AddForce(new Vector2(0,jumForce),ForceMode2D.Impulse);
                SetAnimacion(JUMP);
            }
        }
    }
    void SetAnimacion(int animacion) {
        animator.SetInteger("Estado",animacion);
    }

    void crearBala(float velocidad) {
        if(sr.flipX == false){
            var posicion =transform.position + new Vector3(1.5f,0,0);
            var gb = Instantiate(bala, posicion ,Quaternion.identity);
            var controlador = gb.GetComponent<BalaControllar>();
            controlador.darvelocidadx(5f);
        } else {
            var posicion =transform.position + new Vector3(-1.5f,0,0);
            var gb = Instantiate(bala,posicion,Quaternion.identity);
            var controlador = gb.GetComponent<BalaControllar>();
            controlador.darvelocidadx(-5f);
        }
    }

}
