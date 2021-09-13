using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.InputSystem;

public class AFakeMachine : Interactive
{
    // Start is called before the first frame update
    //一个假的电报机类，因为“序章-战场”中的电报机不需要实际打码功能，为了方便我这里单独写一些代码
    //继承可交互物体基类
    public AudioSource onAudio;
    [Tooltip("拖入黑幕游戏物体")]
    public GameObject blackUI;
    [Tooltip("请拖入序章家中前两幕的背景音乐")]
    public AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCall()
    {
        //当这个假的电报机被唤醒
        //1.检查总线
        AllLinesInfo info = FindObjectOfType<AllLinesInfo>();
        if(info.AreYouOK())
        {
            //若所有线路OK
            //转到场景“序章-家中”，给记录员发信息，让“序章-家中”表现为正确状态
            IndexRecoder indexRecoder = FindObjectOfType<IndexRecoder>();
            indexRecoder.ChangeStageName("序章-家中-已打码");
            onAudio.Play();
            blackUI.SetActive(true);
            FindObjectOfType<BGMPlayer>().ChangedTheBGM(clip);
            Invoke("loadSceneHome",indexRecoder.blackUITime);
        }
        else
        {
            //若还没OK，之后等策划编写新的内容
            Debug.Log("还有线路没有联通");
            FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
            Flowchart.BroadcastFungusMessage("没修完呢");

        }
    }

    void loadSceneHome()
    {
        SceneManager.LoadScene("序章-家中");
    }
}
