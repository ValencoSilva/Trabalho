using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public float velocidade;
    public float distJogador;
    public float angVisao;
    public float forcaTiro;
    public float cadencia;
    public Transform jogador;
    public GameObject projetil;
    public Transform ponta;
    float coolDown;
    void Start()
    {
        coolDown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        if(JogadorProximo())
        {
            //foca no jogador
            transform.LookAt(jogador);
            //atira
            if(coolDown <= 0)
            {
                coolDown = cadencia;
                Quaternion rotacao = Quaternion.FromToRotation(projetil.transform.up, transform.forward);
                GameObject tiro = Instantiate(projetil, ponta.position, rotacao);
                tiro.GetComponent<Rigidbody>().AddForce(transform.forward * forcaTiro);
                Destroy(tiro, 5);
            }
        }
        else
            transform.Rotate(0, velocidade * Time.deltaTime, 0);
    }

    bool JogadorProximo()
    {
        //verifica o perímetro
        if(Vector3.Distance(transform.position, jogador.position) < distJogador)
        {
            //verifica o campo de visão
            Vector3 direcao = jogador.position - transform.position;
            if(Vector3.Angle(transform.forward, direcao) <= angVisao)
            {
                Ray raio = new Ray(transform.position, direcao);
                Debug.DrawRay(raio.origin, raio.direction*distJogador, Color.magenta);

                RaycastHit hit;
                
                //Verifica obstrução
                if(Physics.Raycast(raio, out hit, distJogador))
                {
                    if(hit.transform == jogador)
                        return true;
                }
            }
        }        
            
        return false; 
    }
}
