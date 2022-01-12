using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float jumpspeed = 1.0f;
    float jump;
    public Animator anim;
    float translation;
    
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;


        anim.SetFloat("translation", translation);


        // Move translation along the object's z-axis
        if (translation > 0.1)
        {
            transform.Translate(0, 0, translation);
            transform.Rotate(0, 0.00000001f, 0);
            transform.Rotate(0, -0.00000001f, 0);
        }
        transform.Rotate(0, rotation, 0);
        if (Input.GetMouseButtonDown(0))
        {
            transform.Translate(0, jumpspeed, 0);
        }
    }
}