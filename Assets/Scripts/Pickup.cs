using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameObject collisions;
    public GameObject Picker;
    bool collisionstate;
    int x = 1;
    public GameObject player;
    void Update()
    {
        player.transform.localPosition= new Vector3(0,0,0);
        if (collisionstate)
        
        {
            if (x <= 3)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {

                    Debug.Log("you hit the fucking B button");
                    collisions.GetComponent<Rigidbody>().useGravity = !collisions.GetComponent<Rigidbody>().useGravity;
                    collisions.GetComponent<Rigidbody>().isKinematic = !collisions.GetComponent<Rigidbody>().isKinematic;
                    collisions.transform.SetParent(Picker.transform, false);
                    collisions.transform.localPosition = new Vector3(1.5f, 1.5f, 1.5f);
                    collisions.transform.rotation = Picker.transform.rotation;
                    collisionstate = false;
                    Debug.Log(x + "i");
                    x++;
                }
            }
           
        }
        else if (Picker.transform.childCount!=0)
        {
            collisions = GameObject.Find(Picker.transform.GetChild(2).name);
            if (Input.GetKeyDown(KeyCode.B))
            {
                collisions.transform.SetParent(GameObject.Find("Weights").transform);
                collisions.GetComponent<Rigidbody>().useGravity = true;
                collisions.GetComponent<Rigidbody>().isKinematic = false;
            }
            }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "weight")
        {
            Debug.Log("you hit a weight");
           
            bool collisionstates = true;
            collisionstate = collisionstates;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        collisions = GameObject.Find(collision.gameObject.name);
        if (collision.collider.tag == "weight")
        {
            Debug.Log("you are still hitting weight");
            bool collisionstates = true;
            collisionstate = collisionstates;
           
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "weight")
        {
            bool collisionstates = false;
            collisionstate = collisionstates;
            Debug.Log("exit collision");
        }
    }

}