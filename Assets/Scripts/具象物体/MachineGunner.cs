using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunner : MonoBehaviour
{
    //机枪手类，控制检测前方一片区域的敌人
    // Start is called before the first frame update
    private bool hasBeHit = false;//是否已被打中
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发器是敌人的前方监测区域，当玩家进入检测区域，机枪手进入射击状态，目前用变红表示
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !hasBeHit)//同时需要满足未被击中这个条件
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    //当玩家退出检测区域，停止射击状态,变为通常状态，现在用白色表示
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    //碰撞体是机枪手自身的碰撞体，如果被投掷物砸中，则陷入昏迷状态，目前用绿色表示
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "投掷物")
        {
            hasBeHit = true;//标记自身已被击中
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }


}
