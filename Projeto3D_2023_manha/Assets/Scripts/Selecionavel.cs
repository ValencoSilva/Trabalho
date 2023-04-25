using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionavel : MonoBehaviour
{
    public string texto;
    public Material original;
    public Material selecionado;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = original;
    }

    public void AtivaSelecao()
    {
        rend.material = selecionado;
    }

    public void DesativaSelecao()
    {
        rend.material = original;
    }
}
