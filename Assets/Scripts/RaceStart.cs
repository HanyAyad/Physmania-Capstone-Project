using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStart : MonoBehaviour
{
    public GameObject racerid;
    public Animator race;
    bool Racewin=false;
    int iD;
    bool racestart = false;
    public List<GameObject> racers = new List<GameObject>();
    private void Update()
    {
        race.SetInteger("Racer", racerid.GetComponent<Buttonincrease>().n);
        race.SetBool("Racestart", racestart);

    }
   private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.B))
        {
            racers[racerid.GetComponent<Buttonincrease>().n].SetActive(true);
            race.Play("startrace");        
            if (collision.collider.tag == "player")
            {
                racestart = true;
                race.SetBool("Racewin", Racewin);
                if (racerid.GetComponent<Buttonincrease>().n == 1)
                {
                Racewin = true;
                }
                else
                {
                Racewin = false;
                }
            }
        }
    }
}
