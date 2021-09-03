using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    // 掩体类，控制第二关中挡板
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("看到玩家了！");
        //当玩家进入触发器，使玩家标记自身为掩护状态
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<M_Player>().YouAreCovered();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //当玩家进入触发器，使玩家标记自身为掩护状态
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<M_Player>().YouAreLosingCover();
        }
    }
}
