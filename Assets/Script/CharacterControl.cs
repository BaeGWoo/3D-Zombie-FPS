using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3.0f;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       // transform.forward = Camera.main.transform.forward;

        float x = Input.GetAxis("Horizontal");

        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0, z);
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
    }
}
