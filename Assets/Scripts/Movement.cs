using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
   private float speed = 0;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  
        float moveY = Input.GetAxis("Vertical"); 

        Vector3 movement = transform.right * moveX + transform.left * moveY;


        transform.Translate(movement * Time.deltaTime * speed);
        //transform.Rotate();
    }
}
