using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class VeteranSacrifice : Event
{
    //事件：老兵牺牲

    private CinemachineVirtualCamera M_Camera;//虚拟相机组件
    private Vector3 origin;//原始相机追踪偏移量
    private CinemachineTransposer cinemachineTransposer;//相机追踪数据结构
    private Vector3 target;//目标偏移量，通过修改这个达到转移镜头的目的
    [Tooltip("请填入镜头移动的速度")]
    public float speed;

    [Tooltip("要召唤，得先有，对吧？拖进炮弹的预制体")]
    public GameObject shell;
    [Tooltip("召唤的炮弹需要知道自己属于哪个轰炸区，请拖入其轰炸区")]
    public BombingArea bombingArea;
    private bool hasBeenOnCall;//记录事件是否被触发的变量



    void Start()
    {
        M_Camera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineTransposer = M_Camera.GetCinemachineComponent<CinemachineTransposer>();
        target = cinemachineTransposer.m_FollowOffset;
        origin = target;
    }

    void FixedUpdate()
    {
        if(!target.Equals(cinemachineTransposer.m_FollowOffset))//当没到目标的时候才移动
        {
            //每帧都要使得相机的offset向目标移动
            cinemachineTransposer.m_FollowOffset += (target - cinemachineTransposer.m_FollowOffset)*//目标偏移量
                                                    Time.fixedDeltaTime*//使其与时间无关
                                                    speed;//乘以速度
        }
    }
    public IEnumerator SelfOnCall()
    {
        //1.关闭玩家操作地图
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
        //*让老兵转个身放置牺牲后穿模
        FindObjectOfType<Veteran>().transform.localScale = new Vector3(
            //x
            FindObjectOfType<Veteran>().transform.localScale.x*-1,
            //y
            FindObjectOfType<Veteran>().transform.localScale.y,
            //z
            FindObjectOfType<Veteran>().transform.localScale.z
        );
        //2.移动相机至老兵位置
        target = new Vector3(-19.8600006f,-0.600000024f,-10f)*3;
        //3.召唤一颗导弹在老兵头顶
        Shell thisShell = Instantiate(shell,new Vector3(43.9799995f,10.01999998f,0),Quaternion.identity).
        GetComponent<Shell>();
        thisShell.M_BombingArea = bombingArea;
        thisShell.YouAreSpecal();
        //4.打开老兵的碰撞体，等待播放完毕老兵死亡动画
        FindObjectOfType<Veteran>().GetComponent<BoxCollider2D>().isTrigger = false;
        //5.若干秒后，使镜头返回主角，顺便让主角转个身
        yield return new WaitForSeconds(5f);
        FindObjectOfType<M_Player>().TurnAround();
        target = origin;
        //7.恢复玩家操作地图
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("PlayerNormal");
        //8.关闭老兵碰撞体方便玩家回头查看
        FindObjectOfType<Veteran>().GetComponent<BoxCollider2D>().isTrigger = true;
        //9.标记自己已经被触发过
        hasBeenOnCall = true;
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //当玩家进入事件范围内
            if(!hasBeenOnCall)StartCoroutine("SelfOnCall");
        }
    }
}
