using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonincrease : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public GameObject racer;
    public List<GameObject> racers = new List<GameObject>();
    public int n=0;
    private void Start()
    {
        racer.GetComponent<Image>().sprite = sprites[n]; 
    }
    private void Update()
    {
        Debug.Log(sprites.Count + " " + racers.Count);
        Debug.Log(n);
        if (n >= sprites.Count - 1)
        {
            n = sprites.Count - 1;
            Debug.Log(n);   
        }
        racer.GetComponent<Image>().sprite = sprites[n];
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag== "Player")
        {
            
            Debug.Log("hit");
            if (Input.GetKeyDown(KeyCode.B))
                if (n - 1 >= sprites.Count || n < 0)
                {
                    n = 0;
                    Debug.Log(n);
                    racers[n].SetActive(false);
                }
                else
                {
                    racers[n].SetActive(false);
                    n++;
                }
        }
    }
}