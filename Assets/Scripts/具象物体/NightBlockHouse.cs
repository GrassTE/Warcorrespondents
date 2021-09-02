using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBlockHouse : MonoBehaviour
{
    // Start is called before the first frame update
    //晚上的碉堡类
    //碉堡类敌人的控制代码

    [Tooltip("请填入开枪的间隔时间")]
    public float firingInterval;
    private ShootingArea[] shootingAreas;
    private bool isShooting = false;//记录此时自己是否正在射击
    [Tooltip("请拖入两灯游戏物体")]
    public GameObject[] lights;

    void Start()
    {
        shootingAreas = new ShootingArea[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            shootingAreas[i] = transform.GetChild(i).
                                gameObject.AddComponent<ShootingArea>();//给每个子物体挂上射击区的脚本
            //并且把它的脚本送到数组里面，免去以后再遍历拖慢速度
        }
        InvokeRepeating("ShootOrStopShoot",firingInterval,firingInterval);
    }

    void Update()
    {
        if(isShooting) Shooting();//如果正在射击，每帧检查射击区
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.tag == "Player")
    //     {
    //         //当玩家进入监视区，开始每隔时间进行扫射
    //         InvokeRepeating("ShootOrStopShoot",firingInterval,firingInterval);
    //     }
    // }

    // void  OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.tag == "Player")
    //     {
    //         //当玩家退出监视区，取消扫射的Invoke
    //         CancelInvoke("ShootOrStopShoot");
    //     }


    // }

    //定时触发，反正就是更改射击状态，射到不射或者不射到射
    private void ShootOrStopShoot()
    {
        if(isShooting)//如果在开火
        {
            isShooting = false;//别让它开了
            foreach(GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
        else//如果没在开火
        {
            isShooting = true;//标记让它开火
            foreach(GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }
    //正在射击的时候触发，每帧检测是否被击中
    private void Shooting()
    {
        foreach(ShootingArea s in shootingAreas)
        {
            if(s.IsPlayerHere())
            {
                Debug.Log("玩家被击中！");
            }
        }
    }

    private class ShootingArea : MonoBehaviour
    {
        //射击区类，我懒得再单写一个脚本了，里面东西很少
        private bool isPlayerHere = false;//记录玩家是否在内部

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                //当玩家进入射击区，更改判断标志
                isPlayerHere = true;
            }
        }
        void  OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                //当玩家退出射击区，更改判断标志
                isPlayerHere = false;
            }
        }
        
        public bool IsPlayerHere(){return isPlayerHere;}//返回玩家是否在这个射击区内的结果
    }
}
