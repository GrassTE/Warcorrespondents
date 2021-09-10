using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AReadyMachine : Interactive
{
    //控制家里移开水缸后的电报机
    public BoxCollider2D m_Collider;
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        m_Collider.enabled = false;
    }
    public override void OnCall()
    {
        //交互后，改变玩家形象
        FindObjectOfType<M_Player>().transform.Find("包").gameObject.SetActive(true);
        FindObjectOfType<M_Player>().transform.Find("包带").gameObject.SetActive(true);
        //播放穿上行囊的音效
        GetComponent<AudioSource>().Play();

        //随后删除自己(不要删！不然音效放不出来，我们直接关闭这个物体的碰撞体和图片就可以了)
        FindObjectOfType<M_Player>().catched = null;
        // Destroy(gameObject);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
