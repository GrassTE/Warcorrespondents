using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Door : Interactive
{
    //可交互对象：门的控制类
    [Tooltip("拖入黑幕")]
    public GameObject blackUI;
    [Tooltip("拖入第一关的BGM")]
    public AudioClip clip;
    public override void OnCall()
    {
        //在开门演出的多态，当门被唤醒，显示CG
        if(FindObjectOfType<IndexRecoder>().stageName == "开门演出")
        {
            CGAdministrator administrator = FindObjectOfType<CGAdministrator>();
            administrator.CallACG("暂用-战友");
        }

        //如果是在准备出发这一幕被唤醒，则检查是否捡起背包
        if(FindObjectOfType<IndexRecoder>().stageName == "准备出发")
        {
            if(FindObjectOfType<M_Player>().transform.Find("包").gameObject.activeSelf)//如果已经捡起背包
            {
                // //加载第一关场景
                // SceneManager.LoadScene("第一关");
                blackUI.SetActive(true);
                FindObjectOfType<BGMPlayer>().ChangedTheBGM(clip);
                Invoke("LoadScenen",FindObjectOfType<IndexRecoder>().blackUITime);
            }
            else
            {
                //弹出对话，要先拿包
                Flowchart.BroadcastFungusMessage("先拿包吧");
                FindObjectOfType<M_Player>().GetComponent<PlayerInput>().SwitchCurrentActionMap("NullMap");
            }
        }
    }

    private void LoadScenen()
    {
        SceneManager.LoadScene("第一关");
    }
}
