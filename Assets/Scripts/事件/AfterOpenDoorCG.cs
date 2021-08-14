using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterOpenDoorCG : Event
{
    //事件：当开门的CG播完
    public override void OnCall()
    {
        //找到信息记录者，改变演出名为【准备出发】，为呈现多态作准备
        IndexRecoder indexRecoder = FindObjectOfType<IndexRecoder>();
        indexRecoder.ChangeStageName("准备出发");
        
        //再次切换场景到【序章-家中】
        SceneManager.LoadScene("序章-家中");
    }
}
