using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public Text textovida;
    public Text textoBalas;
    public Text textoZombie;
    public Text textoKey;

    public GameObject[] playersobjects;
    public GameData datajuego;


    // Players
    public Image imageComponent;
    public Sprite[] players;
    public int currentplayer = 0;

    public int contadorvida;
    // public int contadorBalas;
    public int contadorZombie1;
    public int contadorZombie2;
    public int contadorZombie3;

    public bool llave;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // imageComponent = GetComponent<Image>();
        contadorvida = 3;
        // contadorBalas = 0;
        contadorZombie1 = 0;
        contadorZombie2 = 0;
        contadorZombie3 = 0;
        currentplayer = 0;
        llave = false;
        LoadGame();
        cambiarPersonaje();
        cargarPersonajeObject();
        audioSource = GetComponent<AudioSource>();
        
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
        if (currentplayer==0) {
            textoZombie.text = "ZOMBIES: " + contadorZombie1;
        } else if ( currentplayer==1) {
            textoZombie.text = "ZOMBIES: " + contadorZombie2;
        } else {
            textoZombie.text = "ZOMBIES: " + contadorZombie3;
        }
    }
    private void printLlave() {
        textoKey.text = "Tiene LLave";
    }
    public void matarZombie() {
         if (currentplayer==0) {
            contadorZombie1++;
        } else if ( currentplayer==1) {
            contadorZombie2++;
        } else {
           contadorZombie3++;
        }
        printZombie();
    }
    public void cogerLlave() {
        Debug.Log("Llave");
        this.llave = true;
        printLlave();
    }

    public int TotalZombies() {
        if (currentplayer==0) {
            return this.contadorZombie1;
        } else if ( currentplayer==1) {
            return this.contadorZombie2;
        } else {
            return this.contadorZombie3;
        }
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
        if(players.Length > 0) {

            imageComponent.sprite = players[currentplayer];
        }
        printVidas();
        printZombie();
    }

    public void seleccionarPersonaje() {

    }

    public void SaveGame(){
        var filePath = Application.persistentDataPath + "/dbjuego.dat";
        FileStream file;

        if(File.Exists(filePath))
            file = File.OpenWrite(filePath);
        else    
            file = File.Create(filePath);

        GameData data = new GameData();
        data.vidas = contadorvida;
        data.puntos1 = contadorZombie1;
        data.puntos2 = contadorZombie2;
        data.puntos3 = contadorZombie3;
        data.personaje = currentplayer;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();

    }


      public void LoadGame() {
        var filePath = Application.persistentDataPath + "/dbjuego.dat";
        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }
        else    {
            Debug.LogError("No se encontreo archivo");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        //utilizar los datos guardados
        contadorvida = data.vidas;
        contadorZombie1 = data.puntos1;
        contadorZombie2= data.puntos2;
        contadorZombie3 = data.puntos3;
        currentplayer = data.personaje;
        Debug.Log(currentplayer);
        printVidas();
        printZombie();
    }

    public void cargarPersonajeObject () {
        if(playersobjects.Length > 0) {
            // Instantiate(playersobjects[currentplayer],transform.position,Quaternion.identity);
              var shieldPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(playersobjects[currentplayer],
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                // var controller =gb.GetComponent<>();
        }
    }
    public void irMenu () {
        Debug.Log("Aqui");
        SaveGame();
        SceneManager.LoadScene(2);
    }
    public void irScena1 () {
        Debug.Log("Scena1");
        Debug.Log(currentplayer);
        SaveGame();
        SceneManager.LoadScene(0);
    }
    public void irScena2 () {
        Debug.Log("Aqui2");
        Debug.Log(currentplayer);
        SaveGame();
       if (currentplayer==0) {
            if(contadorZombie1>=5) {
                SceneManager.LoadScene(0);
            }
        } else if ( currentplayer==1) {
            if(contadorZombie2>=5) {
                SceneManager.LoadScene(0);
            }
        } else {
            if(contadorZombie3>=5) {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void irScena3 () {
        SaveGame();
        if (currentplayer==0) {
            if(contadorZombie1>=10) {
                SceneManager.LoadScene(0);
            }
        } else if ( currentplayer==1) {
            if(contadorZombie2>=10) {
                SceneManager.LoadScene(0);
            }
        } else {
            if(contadorZombie3>=10) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
