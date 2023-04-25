using UnityEngine;
using System.Collections;

public class seguir : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent Agent;
    public Transform Alvo;

    void Start () {
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }
    
    
    void Update () {
        Agent.SetDestination (Alvo.position);
    }
}
