using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLight : MonoBehaviour
{
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DesLight",0.1f);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesLight()
    {
        Destroy(light);
    }
}
