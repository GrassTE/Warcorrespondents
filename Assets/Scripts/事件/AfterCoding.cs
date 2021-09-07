using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class AfterCoding : Event
{
    //事件：第一关打完码后
    [Tooltip("要召唤，得先有，对吧？拖进炮弹的预制体")]
    public GameObject shell;
    [Tooltip("召唤的炮弹需要知道自己属于哪个轰炸区，请拖入其轰炸区")]
    public BombingArea bombingArea;
    [Tooltip("请拖入黑幕")]
    public GameObject BlackUI;
    void Start()
    {
        OnCall();
    }
    public override void OnCall()
    {
        //*关闭玩家操控地图
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
        //1.关闭电报机界面
        FindObjectOfType<Machine>().m_interface.SetActive(false);
        //2.在玩家旁边生成一颗导弹
        Shell thisShell = Instantiate(shell,new Vector3(116.539998f,5.96999979f,-4.01295185f),Quaternion.identity).
        GetComponent<Shell>();
        thisShell.M_BombingArea = bombingArea;
        thisShell.YouAreSpecal();
        thisShell.target = FindObjectOfType<M_Player>().GetComponent<Animator>();
        //3.导弹爆炸后触发玩家死亡动画，这一段写在导弹类里面
    }
    //4.玩家被炸死开始执行后触发此段，镜头开始缓慢聚焦到主角
    public void OnDeadAnimation()
    {
        StartCoroutine("OnDeadAnimationEnd");//若干秒后执行死亡动画播放完毕后代码
        StartCoroutine("StopDead");//本帧结束后停止死亡动画条件防止反复触发
    }
    private IEnumerator StopDead()
    {
        yield return new WaitForEndOfFrame();
        FindObjectOfType<M_Player>().GetComponent<Animator>().SetBool("IsBoomDead",false);
    }
    //5.当玩家被炸死动画结束后触发此段
    private IEnumerator OnDeadAnimationEnd()
    {
        yield return new WaitForSeconds(1.1f + 3f);//炸死动画1.1秒 + 3秒留给玩家反应
        //黑屏（一张铺满的黑色UI显示）
        BlackUI.SetActive(true);
        yield return new WaitForSeconds(2f);//两秒后，转移场景
        SceneManager.LoadScene("第二关");
    }
}
