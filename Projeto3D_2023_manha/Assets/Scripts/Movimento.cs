using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour{
    CharacterController controller;
    Vector3 movimento;
    float movY;

    public float velocidade;
    public float gravidade;
    public float pulo;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        movY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movY += gravidade;

        //testa de está no chão
        if(controller.isGrounded)
        {
            //print("no chao");
            movY = 0; 
            if(Input.GetButtonDown("Jump"))
            {
                movY += pulo;
                //print("pulo");
            }  
        }        

        //não tem y
        movimento = transform.right * Input.GetAxis("Horizontal");
        movimento += transform.forward * Input.GetAxis("Vertical");        
        movimento = movimento.normalized * velocidade;
        //gravidade
        movimento.y = movY;

        controller.Move(movimento * Time.deltaTime);
    }
}
