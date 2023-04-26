using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public float rayDist;
    Selecionavel selecionado;
    public Text toolTip;
    public float vida;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Enemy"))
        {
        vida -= 50;
        print(vida);
        }

        if(vida <= 0)
        print("morreu");
        if(col.gameObject.CompareTag("tiro"))
        {
        vida -= 10;
        print(vida);
        }

        if(vida <= 0)
            print("morreu");

    }
    void OnTriggerEnter(Collider col)
    {

        

        
    }

    

    // Update is called once per frame
    void Update()
    {
        //projeta raio a partir do mouse
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * rayDist, new Color(250,0,0,100));

        //objeto que guarda as infos da colisao
        RaycastHit hit;
        Selecionavel selecao = null;

        //testa a colisao
        if(Physics.Raycast(raio, out hit, rayDist))
        {
            selecao = hit.transform.GetComponent<Selecionavel>();
        }

        if(selecao != null) selecao.AtivaSelecao();
        
        if(selecao != selecionado) //nova seleção
        {
            if(selecionado != null) selecionado.DesativaSelecao();
            selecionado = selecao;
        }

        if(selecionado != null)
        {
            toolTip.text = selecionado.texto;
            toolTip.gameObject.SetActive(true);
            if(Input.GetMouseButtonDown(1))
            {
                Clicavel obj = selecionado.GetComponent<Clicavel>();
                if(obj != null) obj.Ativar(); //polimorfismo
            }            
        }
        else
        {
            toolTip.text = "";
            toolTip.gameObject.SetActive(false);
        }
    }
}
