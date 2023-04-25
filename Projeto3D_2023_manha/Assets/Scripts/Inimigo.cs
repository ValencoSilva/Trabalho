using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public GameObject morrer;
    void Start()
    {
        vida = 5;
    }

    // Update is called once per frame
    void Morrer(){
        if(vida >= 0){
            GameObject.Destroy(morrer);
        }
    } 
    }

