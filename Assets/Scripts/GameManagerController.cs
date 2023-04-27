using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public Text textovida;
    public Text textoBalas;
    public Text textoZombie;

    public int contadorvida;
    // public int contadorBalas;
    public int contadorZombie;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        contadorvida = 3;
        // contadorBalas = 0;
        contadorZombie = 0;
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
    public void matarZombie() {
        contadorZombie++;
        printZombie();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
