using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{

    
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-4,rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag ==  "Bala") {
            Destroy(this.gameObject);
        }
    }
}
