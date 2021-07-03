using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class M_Player : MonoBehaviour
{
    //玩家类，主要用来控制玩家
    private IndexRecoder indexRecoder;//记录组件，内存方便修改的参数
    private Vector2 velocity;//逻辑速度，通过计算获得，最后加在理论速度上
    private Rigidbody2D m_rigidbody;//自身刚体组件
    private int inputDir;//输入方向方向,-1\0\1
    //public GameObject bullet;//子弹预制体
    private int faceDir;//面部朝向，-1、1
    private float runSpeedMultiple = 1f;//速度倍率，在按下和释放跑步后被修改
    public Interactive catched;//所捕捉到的可交互对象
    void Start()
    {
        //获取数值记录组件，方便策划修改暴露参数
        indexRecoder = FindObjectOfType<IndexRecoder>();
        //获取自身刚体组件
        m_rigidbody = GetComponent<Rigidbody2D>();
        //默认面部朝右
        faceDir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    //当水平轴有输入
    public void OnMoveHorizons(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        //输入只有对移动方向和面部朝向的更改
        if(value > 0)
        {
            inputDir = 1;
            faceDir = 1;
        }
        
        else if(value < 0) 
        {
            inputDir = -1;
            faceDir = -1;
        }
        else inputDir = 0;
        //修改面部朝向
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x)*faceDir,
            transform.localScale.y,
            transform.localScale.z);
    }

    public void OnFire()
    {
        // GameObject temp = Instantiate(bullet,m_rigidbody.position,Quaternion.identity);
        // temp.GetComponent<Bullet>().SetDir(faceDir);
    }

    private void Move()
    {
        //指定水平方向的速度
        m_rigidbody.velocity = new Vector2(indexRecoder.playerMoveSpeed* //记录文件中的玩家速度乘以
                                            inputDir*//输入的方向乘以
                                            runSpeedMultiple,//速度的倍率，对付跑步时候的需要
                                            m_rigidbody.velocity.y//y轴的速度不变
                                            );

    }

    private void OnJump()
    {
        //跳的时候给一个垂直向上的速度
        m_rigidbody.velocity = new Vector2(0,indexRecoder.playerJumpSpeed);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)//如果刚按下跑步键
        {
            runSpeedMultiple = indexRecoder.runSpeedMultiple;//把本地的速度倍率变成数值记录器中的倍率
        }
        else if(context.canceled)//如果刚松开跑步键
        {
            runSpeedMultiple = 1f;//恢复本地速度倍率为1
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            //可交互对象都有UI界面。当按下交互键后，显示交互界面
            if(catched != null)
            {
                catched.OnCall();
            }
        }

        if(context.canceled)
        {
            //可交互对象电话线比较特殊，需要额外检测按钮松开的瞬间
            if(catched != null)
            {
                catched.StopRepareTheTelephoneLine();
            }
        }
    }

    public void OnCoding(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            if(catched != null)
            {
                if(context.duration < indexRecoder.dotRoLineTime)//如果小于界限时间
                {
                    catched.Coding(".");
                }
                else
                {
                    catched.Coding("-");
                }
            }
           
        }
    }


}
