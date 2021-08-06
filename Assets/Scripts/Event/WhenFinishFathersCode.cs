using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class WhenFinishFathersCode : Event
{
    // Start is called before the first frame update
    //具体事件：当玩家打完了父亲教的电码
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCall()
    {
        Flowchart.BroadcastFungusMessage("玩家打完了父亲教的电码");
        //Debug.Log("打完了，执行下一步的代码请写这里");
    }
}
