using UnityEngine;

public class Colisao : MonoBehaviour
{
    public GameObject objetoDesativado;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ponte"))
        {
            objetoDesativado.SetActive(false);
            Debug.Log("Objeto desativado!");
        }
        else{
            objetoDesativado.SetActive(true);
            Debug.Log("Objeto ativado!");
        }
    }
}
