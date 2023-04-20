using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject Enemigo;

    private float  tiempoCrear = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoCrear += Time.deltaTime;
        if(tiempoCrear >= 3f) {
            tiempoCrear = 0f;
            Debug.Log("Correr izquierda :" + tiempoCrear); 
            Instantiate(Enemigo,transform.position,Quaternion.identity);
        }
    }
}
