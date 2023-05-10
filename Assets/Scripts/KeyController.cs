using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManagerController gameManagerController;
    void Start()
    {
    gameManagerController = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag ==  "Player") {
            
            gameManagerController.cogerLlave();
            Destroy(this.gameObject);
        }
    }
    
}
