using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class AfterReparedTheMachine : Event
{
    private RepairBench repairBench;
    private CinemachineVirtualCamera Vcamera;
    [Tooltip("请拖入巡逻敌人")]
    public Patrolman patrolman1;
    [Tooltip("请拖入巡逻敌人")]
    public Patrolman patrolman2;
    private M_Player player;
    [Tooltip("请拖入电报机UI界面")]
    public GameObject MachineUI;
    [Tooltip("请拖入倒计时UI")]
    public Text countDown;
    private int leftTime = 10;
    public GameObject blackUI;
    private Machine machine;

    public WVParallax parallax;
    public AudioSource gunAudio;
    void Start()
    {
        repairBench = FindObjectOfType<RepairBench>();
        Vcamera = FindObjectOfType<CinemachineVirtualCamera>();
        player = FindObjectOfType<M_Player>();
        machine = FindObjectOfType<Machine>();
        //OnCall();
    }
    //事件，当修完电报机
    public override void OnCall()
    {
        StartCoroutine("Process");
    }

    private IEnumerator Process()
    {
        //parallax.canParallax = false;
        //1.关闭玩家操作地图
        FindObjectOfType<PlayerInput>().
        SwitchCurrentActionMap("NullMap");
        //2.给玩家若干反应时间，然后关闭修理电报机界面
        yield return new WaitForSeconds(0f);
        repairBench.m_interface.SetActive(false);
        //3.再过若干时间，镜头跟踪物改为敌人
        yield return new WaitForSeconds(2f);
        Vcamera.Follow = patrolman1.transform;
        //4.同时，敌人的targe改为玩家
        patrolman1.ChangeTargetTo(player.transform);
        patrolman2.ChangeTargetTo(player.transform);
        patrolman1.GetComponent<Animator>().SetBool("IsRush",true);
        patrolman2.GetComponent<Animator>().SetBool("IsRush",true);
        //5.若干时间后，镜头跟踪物改为玩家
        yield return new WaitForSeconds(4f);
        Vcamera.Follow = player.transform;
        //6.若干短时间后，敌人的target改为普通巡逻点
        yield return new WaitForSeconds(1f);
        patrolman1.ChangeTargetTo(patrolman1.point1);
        patrolman2.ChangeTargetTo(patrolman1.point1);
        //7.若干时间后，弹出对话【被发现了】
        Flowchart.BroadcastFungusMessage("被发现了");
    }
    public void AfterChat()
    {
        machine.OnCall();
        player.catched = machine;
        MachineUI.SetActive(true);
        player.GetComponent<PlayerInput>().
        SwitchCurrentActionMap("PlayerInCoding");
        countDown.gameObject.SetActive(true);
        InvokeRepeating("CountDown",0,1);
    }
    private void CountDown()
    {
        countDown.text = "倒计时" + leftTime;
        leftTime--;
        if(leftTime == 0)
        {
            //当倒计时结束
            blackUI.SetActive(true);
            Invoke("PlayGunAudio",1.5f);
        }
    }

    private void PlayGunAudio()
    {
        gunAudio.Play();
    }

}
