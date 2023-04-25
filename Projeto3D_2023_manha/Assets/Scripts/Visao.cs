using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    public float sensibilidade;
    public Transform cabeca;
    float rotX;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxis("Mouse Y"));
        float rotY = Input.GetAxis("Mouse X") * sensibilidade;
        transform.Rotate(0, rotY, 0);

        rotX += -Input.GetAxis("Mouse Y") * sensibilidade;
        rotX = Mathf.Clamp(rotX, -60, 50);
        cabeca.localEulerAngles = new Vector3(rotX, 0, 0);        
    }
}
