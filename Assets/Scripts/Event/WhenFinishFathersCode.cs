using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenFinishFathersCode : Event
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCall()
    {
        Debug.Log("打完了，执行下一步的代码请写这里");
    }
}
