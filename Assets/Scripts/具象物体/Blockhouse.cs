using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blockhouse : MonoBehaviour
{
    //碉堡类敌人的控制代码

    [Tooltip("请填入开枪的间隔时间")]
    public float firingInterval;
    private ShootingArea[] shootingAreas;
    private bool isShooting;//记录此时自己是否正在射击
    [Tooltip("需要因为碉堡开火触发开火动画的都拖进来")]
    public Animator[] fireAnimations;
    [Tooltip("请拖入碉堡警告UI")]
    public Image warningUI;
    [Tooltip("拖入准备图片")]
    public Sprite ready;
    [Tooltip("拖入挥旗图片")]
    public Sprite done;
    private bool isStartedToShowUI = false;//记录自己是否正在准备启动警告UI
    private bool isCencledToShowUI = false;//记录自己是否正在准备关闭警告UI
    [Tooltip("请填入UI出现的速度")]
    public float speed;
    [Tooltip("请填入提前时间，即在警告后多少时间开枪")]
    public float advanceTime;

    public AudioSource blockHouseAudio;//获取音频对象
    public BlackHouseGunLight blackHouseGunLight;//获取碉堡枪光的脚本

    void Start()
    {
        shootingAreas = new ShootingArea[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            shootingAreas[i] = transform.GetChild(i).
                                gameObject.AddComponent<ShootingArea>();//给每个子物体挂上射击区的脚本
            //并且把它的脚本送到数组里面，免去以后再遍历拖慢速度
        }
    }

    void Update()
    {
        if(isShooting) Shooting();//如果正在射击，每帧检查射击区
        if(isStartedToShowUI && warningUI.fillAmount < 1)//如果正在启动UI，每帧加一点fill直到加满
        {
            warningUI.fillAmount += speed*Time.deltaTime;
        }
        if(isCencledToShowUI && warningUI.fillAmount > 0)//如果正在关闭UI，每帧减一点fill直到清空
        {
            warningUI.fillAmount -= speed*Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //当玩家进入监视区，开始每隔时间进行扫射
            InvokeRepeating("ShootOrStopShoot",firingInterval,firingInterval);
            //启动警告UI
            isCencledToShowUI = false;
            isStartedToShowUI = true;
            //每隔一定时间进行警告，即替换UI图片
            InvokeRepeating("ReplaceWarningUIImage",firingInterval - advanceTime,firingInterval);
        }
    }

    void ReplaceWarningUIImage()
    {
        if(!isShooting)
        {
            warningUI.sprite = done;
        }
        else
        {
            warningUI.sprite = ready;
        }
    }

    void  OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //当玩家退出监视区，取消扫射的Invoke
            CancelInvoke("ShootOrStopShoot");
            CancelInvoke("ReplaceWarningUIImage");
            isCencledToShowUI = true;
            isStartedToShowUI = false;
            warningUI.sprite = ready;
        }


    }

    //定时触发，反正就是更改射击状态，射到不射或者不射到射
    private void ShootOrStopShoot()
    {
        if(isShooting)//如果在开火
        {
            blockHouseAudio.Stop();
            blackHouseGunLight.isFire = false;
            isShooting = false;//别让它开了
            //关闭所有动画组件的开火动画
            foreach(Animator fire in fireAnimations)
            {
                fire.SetBool("IsFiring",false);
            }
        }
        else//如果没在开火
        {
            blockHouseAudio.Play();
            blackHouseGunLight.isFire = true;
            isShooting = true;//标记让它开火

            //打开所有动画组件的开火动画
            foreach(Animator fire in fireAnimations)
            {
                fire.SetBool("IsFiring",true);
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
