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
    [Tooltip("所捕捉到的可交互对象,不要手动赋值，这个会自己捕捉")]
    public Interactive catched;//所捕捉到的可交互对象
    private bool throwingState = false;//记录当前是否在投掷状态
    private PlayerInput playerInput;//自身输入组件，用来切换操控地图
    private bool canAdjustTheAngle = false;//记录此时自己是否能调整投掷角度
    private float throwingAngle = 45f;//记录投掷的角度.默认是45°
    private float throwingAngleDir;//记录此时投掷角度变化的速度，包括大小和方向，-1~1表示
    [Tooltip("投掷物的预制体")]
    public GameObject missile;//投掷物的预制体
    [Tooltip("投掷物抛出点")]
    public Transform throwOffset;//记录一下抛出点的位置
    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();//获取数值记录组件，方便策划修改暴露参数    
        m_rigidbody = GetComponent<Rigidbody2D>();//获取自身刚体组件
        faceDir = 1;//默认面部朝右
        playerInput = GetComponent<PlayerInput>(); //获取自身输入组件
    }

    // Update is called once per frame
    void Update()
    {
        AdjustTheAngle();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void AdjustTheAngle()
    {
        if(canAdjustTheAngle)//如果玩家正在调整角度
        {
            throwingAngle += throwingAngleDir//则让现在的抛出角度加上变化的速度
                             * indexRecoder.rateOfChangeOfThrowingAngle//乘以变化的速率
                             * Time.deltaTime;//使其与时间无关
            Debug.DrawLine(transform.position,
                            new Vector3(transform.position.x + 100*Mathf.Cos(throwingAngle),
                                        transform.position.y + 100*Mathf.Sin(throwingAngle),
                                        transform.position.z),
                            Color.red);
        }
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

    private void Move()
    {
        //指定水平方向的速度
        m_rigidbody.velocity = new Vector2(indexRecoder.playerMoveSpeed* //记录文件中的玩家速度乘以
                                            inputDir*//输入的方向乘以
                                            runSpeedMultiple,//速度的倍率，对付跑步时候的需要
                                            m_rigidbody.velocity.y//y轴的速度不变
                                            );

    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if(context.started)//如果按下投掷键，表示可以开始控制角度了
        {
            canAdjustTheAngle = true;
        }
        if(context.canceled)//如果是刚松开投掷键，表示要丢东西了
        {
            Throw();
        }
    }

    public void OnAdjustTheAngle(InputAction.CallbackContext context)
    {throwingAngleDir = context.ReadValue<float>();}//把收到的轴的值交给角度变化的大小和方向

    private void Throw()
    {
        Debug.Log("我投出手上拿着的东西了");
        Rigidbody2D rigidbodyOfMissile = 
            Instantiate(missile,throwOffset.position,Quaternion.identity).GetComponent<Rigidbody2D>();
        rigidbodyOfMissile.velocity = new Vector2(indexRecoder.strengthOfThrowing*Mathf.Cos(throwingAngle),
                                                  indexRecoder.strengthOfThrowing*Mathf.Sin(throwingAngle));
    }

    //进入跑步状态的控制代码
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

    public void EnterThrowingState()
    {
        throwingState = true;//修改自身记录状态变量，表示正式进入投掷状态
        //1.切换操控地图
        playerInput.SwitchCurrentActionMap("PlayerInThrowing");
        //2.动画相关
        //
    }
    public void QuitThrowingsState(){}

}
