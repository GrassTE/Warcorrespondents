using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RepairBench : Interactive
{
    //修理台类，控制修理相关的功能,继承可交互物体基类
    // Start is called before the first frame update
    private bool isRunning = false;//记录目前是否在使用修理台的变量
    private RectTransform needle;//指针的UI位置组件，用来控制指针旋转
    [Tooltip("请填入指针旋转的速度")]
    public float needleSpeed;//指针旋转速度
    private RectTransform[] areas;//记录三个正确区，60~45~30
    private bool[] areasHasClear;//记录三个正确区是否已被修复
    private RectTransform isReparing;//正在修复的区域
    private bool canRing = false;//记录指针是否能转动的变量
    [Tooltip("请填入当你按下确认后，指针停止的时间")]
    public float stopTime;
    [Tooltip("请拖入修好机器后的事件")]
    public Event endEvent;

    void Start()
    {
        //初始化指针
        needle = m_interface.transform.Find("指针").GetComponent<RectTransform>();
        //初始化正确区域
        areas = new RectTransform[3];
        areas[0] = m_interface.transform.Find("60").GetComponent<RectTransform>();
        areas[1] = m_interface.transform.Find("45").GetComponent<RectTransform>();
        areas[2] = m_interface.transform.Find("30").GetComponent<RectTransform>();
        //初始化已被修复标记
        areasHasClear = new bool[3]{false,false,false};
        //都是从60的开始修，所以初始化正在修的为60
        isReparing = areas[0];
        //把60旋转随机一个角度
        isReparing.rotation = Quaternion.Euler(
                                //x、y不变,都是0
                                0,0,
                                //z
                                Random.Range(0,360)
        ); 
        //给指针赋予针控件
        needle.gameObject.AddComponent<Needle>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)//如果正在运行
        {
            if(canRing)NeedleRun();//让指针转

        }
    }

    private void NeedleRun()
    {
        needle.rotation = Quaternion.Euler(
                                            //x、y不变,都是0
                                            0,0,
                                            //z
                                            needle.rotation.eulerAngles.z +//原先自身角度加上
                                            needleSpeed *//指针的运动速度乘以
                                            -1*//使正值代表顺时针
                                            Time.deltaTime//使其与实践无关
        );       
    }

    public override void OnCall()
    {
        m_interface.SetActive(true);//打开修理页面
        isRunning = true;//标记自身正在修理
        //修改玩家的操作地图到修复机器
        FindObjectOfType<M_Player>().GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerInReparingTheMachine");
        canRing = true;//标记可以开始转动指针
    }

    public override void Comfirm()
    {
        //当传入玩家按下交互键的信号
        //让指针停下
        canRing = false;
        //在若干时间后重新转动指针
        Invoke("ReRing",stopTime);

        //检查判定结果
        if(needle.GetComponent<Needle>().CanYouSuccess())
        {
            //如果成功
            //找到正在修的区域并标记其为已修好
            for(int i = 0; i < areas.Length; i++)
            {
                if(isReparing.Equals(areas[i])) areasHasClear[i] = true;
            }
            //检查是否所有区域都已完成
            if(areasHasClear[0]&&areasHasClear[1]&&areasHasClear[2])
            {
                //如果全都完成
                //关闭界面
                m_interface.SetActive(false);
                //触发结束事件
                endEvent.OnCall();
            }
            else
            {
                //如果还有未完成区域，若干时间后，替换到下一个区域
                Invoke("InitSucceedArea",stopTime);
                
            }
        }
        else
        {
            //如果失败，若干时间后重新转动指针
            Invoke("ReRing",stopTime);
        }
    }

    private void InitSucceedArea()
    {
        //首先找到下一个还没修的区域
        for(int i = 0; i < areas.Length; i++)
        {
            if(areasHasClear[i] == false){isReparing.gameObject.SetActive(false);//关闭上一个修好的区域
                                            isReparing = areas[i];
                                            break;}
        }
        //把它打开
        isReparing.gameObject.SetActive(true);
        //旋转到随机一个角度
        isReparing.rotation = Quaternion.Euler(
                                        //x、y不变,都是0
                                        0,0,
                                        //z
                                        Random.Range(0,360)
        );              
    }

    //重新标记指针可以转动，协程用
    private void ReRing(){canRing = true;}


    private class Needle : MonoBehaviour
    {
        private bool canNow = false;//记录此瞬间按下交互的话，能不能成功

        //当针头进入成功区，标记其为可以成功，否则标记为不可成功
        public void OnTriggerEnter2D(Collider2D other){canNow = true;}
        public void OnTriggerExit2D(Collider2D other){canNow = false;}
        //返回当前是否在成功区内
        public bool CanYouSuccess(){return canNow;}
    }
    

}
