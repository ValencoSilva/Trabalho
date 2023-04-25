using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaClicavel : Clicavel
{
    public GameObject ponte;
   

    public override void Ativar()
    {
        ponte.GetComponent<Ponte>().MudarDirecao();
        
    }

   }

    

