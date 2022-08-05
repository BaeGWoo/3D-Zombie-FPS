using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] int count;
    [SerializeField] Transform[] wayPoint;

    private Transform tempPoint=null;


   public int health;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveNext), 0, 2);
    }

 
    void Update()
    {
        if(tempPoint !=null)
        {
            agent.SetDestination(tempPoint.position);
        }

        if(health<=0)
        {
          
          
            CancelInvoke();
            agent.speed = 0;
            animator.Play("Standing React Death Backward");
            Destroy(gameObject,3);
        }
    }

    private void SetTarget(Transform newTarget)
    {
        CancelInvoke();
        tempPoint = newTarget;
    }

    public void RemoveTarget()
    {
        tempPoint = null;
        InvokeRepeating(nameof(MoveNext), 0, 2);
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

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Character"))
        {
           SetTarget(other.transform);
            transform.LookAt(other.transform);
            agent.SetDestination(tempPoint.position);
        }

     
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Character"))
        {
            transform.LookAt(other.transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Character"))
        {
            RemoveTarget();
        }
    }
}
