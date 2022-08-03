using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] int count;
    [SerializeField] Transform[] wayPoint;

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveNext), 0, 2);
    }

 
    void Update()
    {
        
    }

    public void MoveNext()
    {
        if(agent.velocity==Vector3.zero)
        {
            agent.SetDestination(wayPoint[count++].position);

            if (count >= wayPoint.Length)
                count = 0;
        }
    }
}
