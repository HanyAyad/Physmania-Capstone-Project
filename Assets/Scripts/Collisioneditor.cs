using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisioneditor : MonoBehaviour
{
    public GameObject momentumhitter;
    public GameObject editorui;
    public float initialspeed;
    public InputField velochange;
    public float velocity;
    public float masstotal;
    public Text velotext;
    public Text masstext;
    public GameObject physicaleditor;
    public InputField masschange;
    public GameObject player;
    public float velo;
    public float mass;
    public float[] massValues;
    public float[] velocityValues;
    public Text trials;
    private int n;
    public GameObject spherevcam;

    // Start is called before the first frame update
    void Start()
    {
        editorui.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        editorui.GetComponent<RectTransform>().localScale = physicaleditor.GetComponent<RectTransform>().localScale;
        editorui.GetComponent<RectTransform>().localPosition = physicaleditor.GetComponent<RectTransform>().localPosition;
        editorui.SetActive(true);
        masstotal = momentumhitter.GetComponent<Rigidbody>().mass;
        massValues = new float[5];
        velocityValues = new float[5];
        n = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (editorui.GetComponent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay)
        {
            player.GetComponent<InputScript>().enabled = false;
            if (Input.GetKey(KeyCode.C))
            {
                editorui.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
                editorui.GetComponent<RectTransform>().localScale = physicaleditor.GetComponent<RectTransform>().localScale;
                editorui.GetComponent<RectTransform>().localPosition = physicaleditor.GetComponent<RectTransform>().localPosition;
                player.GetComponent<InputScript>().enabled = true;
            }
        }
        masstext.text = "Mass = " + masstotal;
        velotext.text = "Velocity = " + velocity;
        trials.text = "Past Trials\nMass\tVelocity\n" + massValues[0] + "\t" + velocityValues[0] + "\n" + massValues[1] + "\t" + velocityValues[1] + "\n" + massValues[2] + "\t" + velocityValues[2] + "\n"
            + massValues[3] + "\t" + velocityValues[3] + "\n" + massValues[4] + "\t" + velocityValues[4] + "\n";
    }
    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (editorui.GetComponent<Canvas>().renderMode == RenderMode.WorldSpace)
            {
                editorui.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            }
        }
    }
    public void massadd()
    {
        if (masstotal < 5000)
        {
            mass = masstotal;
            mass = mass + float.Parse(masschange.text);
            Debug.Log(masstotal);
            masstotal = mass;
        }
        else
        {
            masstotal = 5000;
        }
    }
    public void massremove()
    {
        if (mass != 0 || mass < 0)
        {
            mass = masstotal;
            mass = momentumhitter.GetComponent<Rigidbody>().mass;
            mass = mass - float.Parse(masschange.text);
            momentumhitter.GetComponent<Rigidbody>().mass = mass;
        }
        else
        {
            mass = 1;
        }
        Debug.Log(momentumhitter.GetComponent<Rigidbody>().mass);
        masstotal = mass;
    }
    public void velocityincrease()
    {
        if (velocity < 500)
        {
            velo = velocity;
            velo = velo + float.Parse(velochange.text);
            velocity = velo;
            Debug.Log(velocity);
            if (velocity > 500)
            {
                velocity = 500;
            }
        }
    }
    public void velocitydecrease()
    {
        velo = velocity;
        velo = velo - float.Parse(velochange.text);
        velocity = velo;
        Debug.Log(velocity);
    }
    public void applysettings()
    {
        for (int i = 0; i <= 4; i++)
        {
            Debug.Log(i +" "+ velocityValues[i]);
            if ( velocity!=velocityValues[i] || masstotal != massValues[i])
            {
                editorui.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
                editorui.GetComponent<RectTransform>().localScale = physicaleditor.GetComponent<RectTransform>().localScale;
                editorui.GetComponent<RectTransform>().localPosition = physicaleditor.GetComponent<RectTransform>().localPosition;
                momentumhitter.GetComponent<Rigidbody>().mass = masstotal;
                momentumhitter.GetComponent<ConstantForce>().force = new Vector3(-velocity, 0, 0);
                momentumhitter.GetComponent<Rigidbody>().mass = masstotal;
                player.GetComponent<InputScript>().enabled = true;
            }
        }
        velocityValues[n] = velocity;
        massValues[n] = masstotal;
        velocity = 0;
        masstotal = 0;
        n++;
        spherevcam.SetActive(true);
    }
}
