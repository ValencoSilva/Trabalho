using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponte : MonoBehaviour
{
    public Vector3 aberta;
    public Vector3 fechada;
    public bool abrindo;
    public float velocidade; 
    public float velLerp;  
    public GameObject obstaculo;
    
    public void MudarDirecao()
    {
        abrindo = !abrindo;
    }
    
    void Update()
    {
        float passo = velocidade * Time.deltaTime;
        float passoLerp = velLerp * Time.deltaTime;

        if(abrindo)
        {
            transform.position = Vector3.MoveTowards(transform.position, aberta, passo);
            obstaculo.SetActive(false);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, fechada, passoLerp);
        }
    }
}
