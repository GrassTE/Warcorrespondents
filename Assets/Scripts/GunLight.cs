using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunLight : MonoBehaviour
{
    private bool upLight = true;
    public GameObject light;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeLight",1f,0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeLight()
    {
        if (upLight)
        {
            light.SetActive(upLight);
            upLight = false;
        }

        else
        {
            light.SetActive(upLight);
            upLight = true;

        }
    }

    public void Gundead()
    {
        CancelInvoke();
        light.SetActive(false);
    }
}
