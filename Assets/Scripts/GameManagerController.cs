using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public Text textovida;
    public Text textoBalas;
    public Text textoZombie;
    public Text textoKey;

    // Players
    public Image imageComponent;
    public Sprite[] players;
    public int currentplayer = 0;

    public int contadorvida;
    // public int contadorBalas;
    public int contadorZombie;

    public bool llave;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // imageComponent = GetComponent<Image>();
        cambiarPersonaje();
        audioSource = GetComponent<AudioSource>();
        contadorvida = 3;
        // contadorBalas = 0;
        contadorZombie = 0;
        llave = false;
        printVidas();
        printBalas(5);
        printZombie();
    }

    public void perderVida() {
        contadorvida--;
        printVidas();
        if(contadorvida == 0) {
            Time.timeScale = 0;
            audioSource.Stop();
        }
    }
    // public void ganarBala() {
    //     contadorBalas++;
    //     printBalas();
    // }

    private void printVidas() {
        textovida.text = "VIDAS: " + contadorvida;
    }
    public void printBalas(int contadorBalas) {
        textoBalas.text = "BALAS: " + contadorBalas;
    }
    private void printZombie() {
        textoZombie.text = "ZOMBIES: " + contadorZombie;
    }
    private void printLlave() {
        textoKey.text = "Tiene LLave";
    }
    public void matarZombie() {
        contadorZombie++;
        printZombie();
    }
    public void cogerLlave() {
        Debug.Log("Llave");
        this.llave = true;
        printLlave();
    }

    public int TotalZombies() {
        return this.contadorZombie;
    }
    public bool HasLlave() {
        return this.llave;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void siguientePersonaje() {
        if (currentplayer == 2 ) {
            currentplayer = 0;
        } else {
            currentplayer++;
        }
        cambiarPersonaje();
    }
    public void anterioirPersonaje() {
        if (currentplayer == 0 ) {
            currentplayer = 2;
        } else {
            currentplayer--;
        }
        cambiarPersonaje();
    }

    public void cambiarPersonaje() {
        imageComponent.sprite = players[currentplayer];
    }

    public void seleccionarPersonaje() {

    }
}
