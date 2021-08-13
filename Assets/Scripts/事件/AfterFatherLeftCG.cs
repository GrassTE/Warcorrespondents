using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterFatherLeftCG : Event
{
    public override void OnCall()
    {
        FindObjectOfType<IndexRecoder>().ChangeStageName("开门演出");//涉及多态，更改一下演出名
        SceneManager.LoadScene("序章-家中");
    }
}
