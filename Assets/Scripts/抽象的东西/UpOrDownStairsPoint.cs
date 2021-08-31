using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpOrDownStairsPoint : MonoBehaviour
{
 //下坑点的控制代码，当触发器监测到玩家进入触发器且下坑方向匹配，则发信给玩家、让其执行下坑动画
    [Tooltip("请填入这个点触发所需要的面部朝向，1代表右，-1代表左")]
    public int dir;
    [Tooltip("请填入这个点的类型，是上梯子还是下梯子，1代表上，-1代表下")]
    public int type;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && other.GetComponent<M_Player>().ReturnFaceDir() == dir)
        {
            //当玩家触发触发器，并且方向和记录方向一致
            if(type == -1)
            other.GetComponent<M_Player>().PlayDownStairAnimation();
            if(type == 1)
            other.GetComponent<M_Player>().PlayUpStairAnimation();
        }
    }
}
