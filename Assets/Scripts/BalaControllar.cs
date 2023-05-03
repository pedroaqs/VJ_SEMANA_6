    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControllar : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidadx = 5f;
    public float velocidady = 0f;
    public GameObject bala1; 
    public GameObject bala2; 
    public bool partirse = true;
    // public GameManagerController gameManagerController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // gameManagerController = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidadx,velocidady);
        if(Input.GetKeyDown(KeyCode.Z) && partirse == true) {
            var posicion1 =transform.position + new Vector3(0,-1,0);
            var gb1 = Instantiate(bala1,posicion1,Quaternion.identity);
            var controlador1 = gb1.GetComponent<BalaControllar>();
            controlador1.darvelocidady(-2f);
            controlador1.quitarPartirse();
            var posicion2 =transform.position + new Vector3(0,1,0);
            var gb2 = Instantiate(bala2,posicion2,Quaternion.identity);
            var controlador2 = gb2.GetComponent<BalaControllar>();
            controlador2.darvelocidady(2f);
            controlador2.quitarPartirse();
            quitarPartirse();
        }
    }
    
    public void darvelocidadx(float _nuevaVelocidad) {
        velocidadx = _nuevaVelocidad;
        // rb.velocity = new Vector2(_nuevaVelocidad,0);
    }
    public void darvelocidady(float _nuevaVelocidad) {
        velocidady = _nuevaVelocidad;
        // rb.velocity = new Vector2(_nuevaVelocidad,0);
    }
    public void quitarPartirse() {
        partirse = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag ==  "Enemy" || other.gameObject.tag ==  "Mapa") {
            // gameManagerController.ganarMoneda();
            Destroy(this.gameObject);
        }
    }



}
