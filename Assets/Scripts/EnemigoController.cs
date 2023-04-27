using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{

    
    Rigidbody2D rb;
    public int golpes_restantes = 2;
    public GameManagerController gameManagerController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManagerController = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-4,rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag ==  "Bala") {
            golpes_restantes--;
            if(golpes_restantes == 0) {
                gameManagerController.matarZombie();
                Destroy(this.gameObject);
            }
        }
    }
}
