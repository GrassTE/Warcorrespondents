using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHouseGunLight : MonoBehaviour
{
    private bool upLight = true;
    public GameObject light1;
    public GameObject light2;

    public bool isFire = false;

    public bool isInvoke = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire && (!isInvoke))
        {
            InvokeRepeating("ChangeLight",0f,0.05f);
            isInvoke = true;
        }

        if (!isFire && isInvoke)
        {
            CancelInvoke();
            isInvoke = false;
            light1.SetActive(false);
            light2.SetActive(false);
        }
    }
    void ChangeLight()
    {
        if (upLight)
        {
            light1.SetActive(upLight);
            light2.SetActive(upLight);
            upLight = false;
        }

        else
        {
            light2.SetActive(upLight);
            light1.SetActive(upLight);
            upLight = true;

        }
    }
}
