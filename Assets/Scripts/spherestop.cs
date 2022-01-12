using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class spherestop : MonoBehaviour
{
    public GameObject theWall;
    private Vector3 initialPosition;
    private Vector3 wallPosition;
    private Quaternion wallRotation;
    private Quaternion initialRotaion;
    private int i;
    public GameObject sphereVcam;
    private void Start()
    {
        initialPosition = gameObject.transform.position;
        wallPosition = theWall.gameObject.transform.position;
        wallRotation = theWall.gameObject.transform.rotation;
        i = 0;
        sphereVcam.SetActive(false);
        sphereVcam.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
        sphereVcam.GetComponent<CinemachineVirtualCamera>().LookAt = gameObject.transform;
    }
    private void Update()
    {
        Debug.Log(gameObject.GetComponent<Rigidbody>().velocity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall")
        {
            
            gameObject.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            gameObject.GetComponent<ConstantForce>().torque = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            sphereVcam.SetActive(false);
            if ( i<=3)
            {
                gameObject.transform.rotation = initialRotaion;
                gameObject.transform.position=initialPosition;
                theWall.gameObject.transform.position = wallPosition;
                theWall.gameObject.transform.rotation = wallRotation;
                i++;
                Debug.Log(i);
            }  
        }
    }
}
