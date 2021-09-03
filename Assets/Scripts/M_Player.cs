using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;
using Cinemachine;

public class M_Player : MonoBehaviour
{
    //玩家类，主要用来控制玩家
    private IndexRecoder indexRecoder;//记录组件，内存方便修改的参数
    private Vector2 velocity;//逻辑速度，通过计算获得，最后加在理论速度上
    private Rigidbody2D m_rigidbody;//自身刚体组件
    private int inputDir;//输入方向方向,-1\0\1
    private int faceDir;//面部朝向，-1、1
    private float runSpeedMultiple = 1f;//速度倍率，在按下和释放跑步后被修改
    [Tooltip("所捕捉到的可交互对象,不要手动赋值，这个会自己捕捉")]
    public Interactive catched;//所捕捉到的可交互对象
    private bool throwingState = false;//记录当前是否在投掷状态
    private PlayerInput playerInput;//自身输入组件，用来切换操控地图
    private bool canAdjustTheAngle = false;//记录此时自己是否能调整投掷角
    [SerializeField]
    private float throwingAngle = 45f;//记录投掷的角度.默认是45°
    private float throwingAngleDir;//记录此时投掷角度变化的速度，包括大小和方向，-1~1表示
    [Tooltip("投掷物的预制体")]
    public GameObject missile;//投掷物的预制体
    [Tooltip("投掷物抛出点")]
    public Transform throwOffset;//记录一下抛出点的位置
    private Animator M_Animator;
    private float strengthOfThrowing;//投掷力度，每次和投掷物堆交互，都会更新这个数值
    public AudioSource machineAudio;
    private bool isCovered = false;//记录自身现在是否被掩护，挡板中使用
    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();//获取数值记录组件，方便策划修改暴露参数    
        m_rigidbody = GetComponent<Rigidbody2D>();//获取自身刚体组件
        faceDir = 1;//默认面部朝右
        playerInput = GetComponent<PlayerInput>(); //获取自身输入组件
        M_Animator = GetComponent<Animator>();

        //为了解决warming，最后阶段请删除，到那时应该不会再有警告
        if(inputDir == 0){}
        //
    }

    // Update is called once per frame
    void Update()
    {
        AdjustTheAngle();
    }

    void FixedUpdate(){}

    // void OnAnimatorMove()//Unity的回调函数，这样做能解决模型无法转向的问题，每帧调用一次
    // {
    //     //Debug.Log(playerAnimator.deltaPosition.magnitude);
    //     m_rigidbody.MovePosition(m_rigidbody.position + (Vector2)(M_Animator.deltaPosition));
    //     //m_RigidBody.MoveRotation(m_Rotation);//当物体有物理组件rigidbody的时候，再修改位置和旋转信息就不要用transfrom了，用刚体自带的Move等方法
    // }

    //返回面部朝向的函数，在上下坑点调用，用来判断是否执行上下坑动画
    public int ReturnFaceDir(){return faceDir;}

    //播放上坑动画
    public void PlayUpAnimation(){M_Animator.SetBool("IsUp",true);}

    //播放下坑动画的函数，在下坑点调用
    public void PlayDownAnimation(){M_Animator.SetBool("IsDown",true);}

    //关闭下坑条件，在动画中添加Event来执行，避免下坑动画重复执行
    public void StopIsDown(){M_Animator.SetBool("IsDown",false);}

    //给自生刚体一个向上的速度，不然无法解决动画上坑y轴被重力控制的问题
    public void GiveAUpForce(){
        if(gameObject.name == "他爸")
        m_rigidbody.velocity = new Vector2(0,6);
        else
        m_rigidbody.velocity = new Vector2(0,8);//匹配不同的两个坑
    }


    //关闭上坑条件，避免重复触发
    public void StopIsUp(){M_Animator.SetBool("IsUp",false);}

    //调整投掷角度的函数
    private void AdjustTheAngle()
    {
        if(canAdjustTheAngle)//如果玩家能调整角度
        {
            throwingAngle += throwingAngleDir//则让现在的抛出角度加上变化的速度
                             * indexRecoder.rateOfChangeOfThrowingAngle//乘以变化的速率
                             * Time.deltaTime;//使其与时间无关
            Debug.DrawLine(throwOffset.position,
                            new Vector3(transform.position.x + 100*Mathf.Cos(throwingAngle),
                                        transform.position.y + 100*Mathf.Sin(throwingAngle),
                                        transform.position.z),
                            Color.red);
           DrawPath(); 
        }
    }

    public void ChangeInputMapToNull()
    {
        playerInput.SwitchCurrentActionMap("NullMap");
    }

    public void ChangeInputMapToNormal()
    {
        playerInput.SwitchCurrentActionMap("PlayerNormal");
    }

    //当玩家在修电报机地图下按下交互键触发
    public void OnComfirm(InputAction.CallbackContext context)
    {
        if(context.started) catched.Comfirm();
    }

    //当水平轴有输入
    public void OnMoveHorizons(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        M_Animator.SetBool("IsWalking",true);
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
        else {inputDir = 0;
              M_Animator.SetBool("IsWalking",false);}
        //修改面部朝向
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x)*faceDir,
            transform.localScale.y,
            transform.localScale.z);
        if(faceDir == -1)throwingAngle = 46f;
        else throwingAngle = 45f;
    }

    //监听投掷按键的函数
    public void OnThrow(InputAction.CallbackContext context)
    {
        if(context.started)//如果按下投掷键，表示可以开始控制角度了
        {
            canAdjustTheAngle = true;
            //动画：进入准备丢的动画
            M_Animator.SetBool("ReadyToThrow", true);
        }
        if(context.canceled)//如果是刚松开投掷键，表示要丢东西了
        {
            if(throwingState)
            {
                M_Animator.SetBool("NowThrow",true);//动画：执行丢这个动作
                Throw();//如果处于投掷阶段，则触发丢
            }
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if(context.started) catched.Quit();//如果按下退出按钮，则执行捕捉到物体的退出功能
    }

    //如果正处于投掷状态，则退出投掷状态的监听函数
    public void OnThrowQuit(InputAction.CallbackContext context){if(throwingState)StartCoroutine("QuitThrowingsState");}

    //监听修改投掷角度的函数
    public void OnAdjustTheAngle(InputAction.CallbackContext context)
    {throwingAngleDir = context.ReadValue<float>();}//把收到的轴的值交给角度变化的大小和方向

    //控制投掷相关的具体函数
    private void Throw()
    {
        Rigidbody2D rigidbodyOfMissile = //并且获得这个投掷物身上的刚体组件
            Instantiate(missile,throwOffset.position,Quaternion.identity).GetComponent<Rigidbody2D>();//生成一个投掷物
        
        //给这个投掷物赋予速度，由目前的角度决定
        rigidbodyOfMissile.velocity = new Vector2(strengthOfThrowing*Mathf.Cos(throwingAngle),
                                                  strengthOfThrowing*Mathf.Sin(throwingAngle));
        
        //扔完后退出投掷状态并且重置相关参数
        StartCoroutine("QuitThrowingsState");
    }
    //在投掷物堆中调用，每次呼叫投掷物堆，都针对此堆更新投掷力度
    public void ChangeStrengthOfThrowingTo(float num)
    {
        strengthOfThrowing = num;
    }

    //进入跑步状态的控制代码
    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)//如果刚按下跑步键
        {
            runSpeedMultiple = indexRecoder.runSpeedMultiple;//把本地的速度倍率变成数值记录器中的倍率
            M_Animator.SetBool("IsRunning",true);//播放跑步动画
        }
        else if(context.canceled)//如果刚松开跑步键
        {
            runSpeedMultiple = 1f;//恢复本地速度倍率为1
            M_Animator.SetBool("IsRunning",false);//关闭跑步动画
        }
    }

    //监听交互按键的函数
    public void OnInteraction(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            //可交互对象都有UI界面。当按下交互键后，显示交互界面
            if(catched != null)
            {
                //触发交互函数，在具象物体中重写这个虚拟功能
                catched.OnCall();
                //如果捕捉对象是电话线
                if(catched != null && catched.tag == "电话线") 
                {
                    //获取其电话线组件，如果其未修好，则执行修理动画
                    if(!catched.GetComponent<TelephoneLine>().HasTheBePrepared())
                    M_Animator.SetBool("IsReparing", true);
                }
            }
        }

        if(context.canceled)
        {
            //可交互对象电话线比较特殊，需要额外检测按钮松开的瞬间
            if(catched != null)
            {
                catched.StopRepareTheTelephoneLine();
                //如果捕捉对象是电话线，停止修电话线动画
                if(catched.tag == "电话线") M_Animator.SetBool("IsReparing", false);
            }
        }
    }

    //当修好了一个电话线，强制打断修电话线动画
    public void HasReparedATelephone()
    {
        M_Animator.SetBool("IsReparing", false);
    }


    //监听打电码的函数
    public void OnCoding(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            machineAudio.Play();
            //如果刚按下打码，把电报机UI图片的把手替换成按下的
            catched.ChangeHandleTo(true);
        }

        if(context.canceled)
        {
            machineAudio.Stop();
            //如果刚松开打码，把电报机UI图片的把手换成松开的
            catched.ChangeHandleTo(false);
            //根据按下期间时长发送打出来的码给电报机
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

    //使自身进入投掷状态的函数
    public void EnterThrowingState()
    {
        throwingState = true;//修改自身记录状态变量，表示正式进入投掷状态
        //1.切换操控地图
        playerInput.SwitchCurrentActionMap("PlayerInThrowing");
        //2.动画相关
        M_Animator.SetBool("throwingState",true);//使自身进入捡石动画
    }
    
    //退出投掷状态的时候
    public IEnumerator QuitThrowingsState()
    {
        throwingState = false;//改变自身标记
        playerInput.SwitchCurrentActionMap("PlayerNormal");//修改自身操控地图
        if(faceDir == 1) throwingAngle = 45f;//恢复投掷角度到45°
        else throwingAngle = 46f;
        canAdjustTheAngle = false;//可修改角度标记改为false
        GetComponent<LineRenderer>().enabled = false;//别画线了
        //关闭动画条件
        M_Animator.SetBool("throwingState",false);
        M_Animator.SetBool("ReadyToThrow",false);
        //为了解决问题需要到下一帧关闭丢出动画指令
        yield return new WaitForEndOfFrame();
        M_Animator.SetBool("NowThrow",false);
    }

    //播放上下楼动画的函数，在楼梯边的触发器调用
    public void PlayDownStairAnimation(){M_Animator.SetBool("IsDownStair",true);}
    public void PlayUpStairAnimation(){}
    //外部调用，让玩家转身
    public void TurnAround()
    {
        transform.localScale = new Vector3(
            transform.localScale.x*-1,
            transform.localScale.y,
            transform.localScale.z);//让玩家转身
    }

    public void YouAreShooting()
    {
        // 当玩家被射中时调用
        M_Animator.SetBool("IsShootDead",true);
        StartCoroutine("StopShootingAnimation");//此帧结束后关闭死亡动画条件
    }    
    private IEnumerator StopShootingAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        M_Animator.SetBool("IsShootDead",false);
    }

    public void YouAreCovered(){isCovered = true;}
    public void YouAreLosingCover(){isCovered = false;}
    public bool AreYouCovered(){return isCovered;}

    //绘制投掷曲线的函数，非常🐂
    public void DrawPath()
    {
        //
        LineRenderer line = GetComponent<LineRenderer>();//获取组件
        line.enabled = true;
        int segmentCount = 18;//定义点数
        line.positionCount = segmentCount;//传入点数
        float gravity=9.8f;//定义重力常量
        Vector2 fireOffset = new Vector2(throwOffset.position.x - transform.position.x, 
                                         throwOffset.position.y - transform.position.y);
        Vector2[] segments = new Vector2[segmentCount];//定义二维向量数组，用来存15个点的位置
        segments[0].Set(transform.position.x + fireOffset.x, transform.position.y + fireOffset.y);//定义起点
        line.SetPosition(0, segments[0]);//把起点位置传入线的起点    
        for (int i = 1; i < segmentCount; i++)//根据时间、循环确定点的位置
        {
            float time = i * Time.fixedDeltaTime * 5;//类似时间间隔的定义，也就是抛物线上的x多久取值一次
            segments[i].x = transform.position.x + //自身位置的x
                            fireOffset.x + //发射偏移量的x
                            time * strengthOfThrowing * Mathf.Cos(throwingAngle);//水平方向位移 = v*t
            segments[i].y = (transform.position.y + fireOffset.y + //自身位置的y
                            time * strengthOfThrowing * Mathf.Sin(throwingAngle) + 
                            (0.5f * gravity * time * time)*-1);//垂直方向位移 = vt + 1/2 * g * t^2
            line.SetPosition(i, segments[i]);  //把算好的点传入线的点集     
        }
    }

}
