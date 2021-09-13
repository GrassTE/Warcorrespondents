using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : Event
{
    //控制追逐战触发的事件代码
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

        }
    }
}
