using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : Interactive
{
    // Start is called before the first frame update


    public Text codeTextView;
    void Start()
    {
        //m_interface = GameObject.Find("MachinePanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Coding(string temp)
    {
        codeTextView.text += temp;
    }


}
