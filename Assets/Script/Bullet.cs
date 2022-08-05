using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject character;

   

    private void Start()
    {
        //character = GameObject.FindGameObjectWithTag("Character");

        Destroy(gameObject, 3);
       
    }

    void Update()
    {
        transform.Translate(character.transform.forward * speed * Time.deltaTime);

       
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            other.gameObject.GetComponentInParent<AIControl>().health -= 20;
            Debug.Log("충돌");
            Destroy(gameObject);
        }
    }
}
