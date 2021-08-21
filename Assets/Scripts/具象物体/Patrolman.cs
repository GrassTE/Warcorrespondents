using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolman : MonoBehaviour
{
    //控制巡逻敌人

    [Tooltip("拖入巡逻点1")]
    public Transform point1;
    [Tooltip("拖入巡逻点2，他将于此两点间往返")]
    public Transform point2;
    [Tooltip("普通移动时的速度")]
    public float walkSpeed;
    [Tooltip("听见响动，冲锋时的速度")]
    public float rushSpeed;
    private float speed;//记录此刻瞬间的速度,不包含方向
    private float velocity;//速度，正值代表向右，用来判断面部朝向
    private Transform target;//当前目标位置
    private bool isInterrupt = false;//记录目前是否被石头落地的声音所吸引
    private float PVelocity = -1f;//记录上一帧的速度,默认上一帧往右走

    // Start is called before the first frame update
    void Start()
    {
        target = point1;//初始化起始目标为巡逻点1
        speed = walkSpeed;//初始化瞬间速度为走路速度
    }

    // Update is called once per frame
    void Update()
    {
        Move();//每帧朝目标移动
    }

    //朝目标移动函数
    private void Move()
    {
        //构造速度向量
        velocity = (target.position - transform.position).x;
        velocity = Mathf.Abs(velocity)/velocity;//把速度标准化为1或者-1，只保留方向
        velocity *= speed;//给速度赋以大小

        //判断是否到达巡逻点
        if(velocity*PVelocity < 0 && !isInterrupt)//速度相乘得负数，说明方向发生改变
        {
            //如果计算速度发生改变，且不是因为被石头打断，说明经过了巡逻点，此时更换目标点为另一个
            if(target.Equals(point1)) target = point2;
            else target = point1;
        }

        //控制面部朝向
        if(velocity > 0) transform.rotation = Quaternion.Euler(0,0,0);
        else transform.rotation = Quaternion.Euler(0,180f,0);

        //移动
        transform.position = new Vector3(
            //x
            transform.position.x +//自身此刻位置 加上
            velocity * //构造好的速度乘以
            Time.deltaTime,//使其与时间无关
            
            //y和z不变
            transform.position.y,
            transform.position.z
        );

        //更新PVelocity
        PVelocity = velocity;
    }


}
