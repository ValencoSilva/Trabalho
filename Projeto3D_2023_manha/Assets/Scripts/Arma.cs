using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    Vector2 centro;
    float coolTime;
    public float distTiro;
    public float forca;
    public GameObject marca;
    public float cadencia;
    public int dano;
    void Start()
    {
        centro = new Vector2(Screen.width/2, Screen.height/2);
        coolTime = 0;
    }

    
    
    void Update()
    {
        coolTime -= Time.deltaTime;

        if(coolTime <= 0 && Input.GetMouseButtonDown(0))
        {
            //colocar o tempo da cadencia
            coolTime = cadencia;
            Ray raio = Camera.main.ScreenPointToRay(centro);
            RaycastHit hit;

            //teste de colisão do tiro
            if(Physics.Raycast(raio, out hit, distTiro))
            {
                if(hit.transform.gameObject.CompareTag("Enemy")){
                    Inimigo enemyHealth = hit.transform.gameObject.GetComponent<Inimigo>();
                    if (enemyHealth != null) {
                    enemyHealth.TakeDamage(dano);
                    
                }
                else{
                    Vector3 pos = hit.point + hit.normal/100;
                    Quaternion rot = Quaternion.FromToRotation(marca.transform.forward, hit.normal);
                    GameObject furo = Instantiate(marca, pos, rot);
                    Destroy(furo, 5);
                }

                if(hit.transform.gameObject.CompareTag("latinha"))
                {
                    Rigidbody rb = hit.transform.gameObject.GetComponent<Rigidbody>();                 

                    if(rb != null)
                        rb.AddForce(Camera.main.transform.forward * forca);

                    Vector3 pos = hit.point + hit.normal/100;
                    Quaternion rot = Quaternion.FromToRotation(marca.transform.forward, hit.normal);
                    GameObject furo = Instantiate(marca, pos, rot, hit.transform);
                    Destroy(furo, 5);
                }
                else{
                
                    Vector3 pos = hit.point + hit.normal/100;
                    Quaternion rot = Quaternion.FromToRotation(marca.transform.forward, hit.normal);
                    GameObject furo = Instantiate(marca, pos, rot);
                    Destroy(furo, 5);
                }
                
            }
        }
        
    }
    }
}