using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBalasController : MonoBehaviour
{
    public GameObject ganarBala;

    private float  tiempoCrear = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoCrear += Time.deltaTime;
        if(tiempoCrear >= 5f) {
            tiempoCrear = 0f;
            Debug.Log("Correr izquierda :" + tiempoCrear); 
            Instantiate(ganarBala,transform.position,Quaternion.identity);
        }
    }
}
