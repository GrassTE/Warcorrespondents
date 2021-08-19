using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WhenPlayerDropInTheHole : Event
{
    //事件：当玩家调到坑里，主要是改变摄像机视角
    private CinemachineVirtualCamera M_Camera;
    private Vector3 origin;
    private CinemachineTransposer cinemachineTransposer;
    private Vector3 target;
    [Tooltip("请填入镜头移动的速度")]
    public float speed;


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


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //当玩家进入事件范围内
            target = new Vector3(6.5f,0.25999999f,-10f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //当玩家离开区域，使视角恢复
            target = origin;
        }
    }
}
