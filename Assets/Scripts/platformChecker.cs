using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class platformChecker : MonoBehaviour
{
    public float weightlimit;
    public GameObject success;
    public GameObject gravitytarget;
    public GameObject targetplatform;
    private Animator anim;
    public Animator targetanim;
    public float totalweight;

    private void Start()
    {
        success.SetActive(false);
        anim = GetComponent<Animator>();
        targetanim = targetplatform.GetComponent<Animator>();
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.collider.tag == "weight")
        {
            float r = Vector3.Distance(gravitytarget.transform.position, collision.gameObject.transform.position);
            Debug.Log(r);
            totalweight = totalweight + collision.gameObject.GetComponent<Rigidbody>().mass;
            float force = (totalweight * gravitytarget.GetComponent<Rigidbody>().mass)/Mathf.Pow(r,2);
            Debug.Log("on platform");
            Debug.Log(force+" force");
            if (force>= weightlimit)
            {
                bool Gravity = true;
                success.SetActive(true);
                anim.SetBool("Gravity",Gravity);
                targetanim.SetBool("Gravity", Gravity);
            }
        }
    }
    
}
