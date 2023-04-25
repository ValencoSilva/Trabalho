using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public int vidaMaxima=3;
    public GameObject morrer;
    void Start()
    {
        vida = vidaMaxima;
    }

    // Update is called once per frame


    public void TakeDamage(int dano) {  
        vida -= dano;
        Debug.Log(vida);
        if (vida <= 0) {
            Morrer();
        }
    }
    void Morrer(){
        
            GameObject.Destroy(morrer);
    }
    
    }

