using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalEscenacontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManagerController gameManagerController;
    private bool botonPresionado = false;
    bool puedePasar = false;
    void Start()
    {
        gameManagerController = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // puedePasar=false;
        pasarBotonFalse();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(botonPresionado);
        if(other.gameObject.tag ==  "Player" && gameManagerController.HasLlave() && gameManagerController.TotalZombies() == 3) {
        //    SceneManager.LoadScene(1);
           puedePasar = true;
        }
    }

    public void pasarBotonTrue() {
        botonPresionado  = true;
        if (puedePasar) {
            SceneManager.LoadScene(1);
        }
    }
    public void pasarBotonFalse() {
        botonPresionado = false;
    }
}
