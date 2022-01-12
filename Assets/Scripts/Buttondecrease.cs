using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttondecrease : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public GameObject racer;
    public GameObject buttonincrease;
    public List<GameObject> racers = new List<GameObject>();

    private void Update()
    {
        if (buttonincrease.GetComponent<Buttonincrease>().n >= sprites.Count - 1)
        {
            buttonincrease.GetComponent<Buttonincrease>().n = sprites.Count - 1;
            Debug.Log(buttonincrease.GetComponent<Buttonincrease>().n);
            racer.GetComponent<Image>().sprite = sprites[buttonincrease.GetComponent<Buttonincrease>().n];
        }
        if (buttonincrease.GetComponent<Buttonincrease>().n < 0)
        {
            buttonincrease.GetComponent<Buttonincrease>().n = 0;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag== "Player")
        {
            Debug.Log("hit");
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (buttonincrease.GetComponent<Buttonincrease>().n - 1 >= sprites.Count || buttonincrease.GetComponent<Buttonincrease>().n < 0)
                {
                    racers[buttonincrease.GetComponent<Buttonincrease>().n].SetActive(false);
                    buttonincrease.GetComponent<Buttonincrease>().n = 0;

                }
                else 
                {
                    racers[buttonincrease.GetComponent<Buttonincrease>().n].SetActive(false);
                    buttonincrease.GetComponent<Buttonincrease>().n = buttonincrease.GetComponent<Buttonincrease>().n - 1;
                }
            }
        }
    }
}