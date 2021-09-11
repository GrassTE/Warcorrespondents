using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhenTheCodeAndConversationAreCompleted : Event
{
    // Start is called before the first frame update
    //事件，当在序章中完成教学并且完成和父亲的第二段对话后
    [Tooltip("请拖入黑幕游戏物体")]
    public GameObject blackUI;
    private IndexRecoder indexRecoder;
    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void  OnCall()
    {
        blackUI.SetActive(true);
        Invoke("LoadScene",indexRecoder.blackUITime);
    }

    private void LoadScene()
    {
        indexRecoder.ChangeStageName("序章-战场");
        SceneManager.LoadScene("序章-战场");
    }


}
