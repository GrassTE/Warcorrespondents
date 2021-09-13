using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationsInfo : MonoBehaviour
{
    //操作说明类，当玩家进入触发器，显示图片，当离开触发器，关闭图片
    public bool isIn = false;
    public SpriteRenderer spriteRenderer;
    [Tooltip("填入提示消隐和出现的速度")]
    public float speed;
    [Tooltip("请输入此操作提示仅在哪一个多态中显示，若不填，则每一个多态都显示")]
    public string showStageName;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void  Update()
    {
        if(isIn && spriteRenderer.color.a < 1)
        {
            spriteRenderer.color = new Color(
                //RBG不变
                spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,
                //a变大
                spriteRenderer.color.a + speed * Time.deltaTime
            );
        }
        if(!isIn && spriteRenderer.color.a > 0)
        {
             spriteRenderer.color = new Color(
                //RBG不变
                spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,
                //a变小
                spriteRenderer.color.a - speed * Time.deltaTime
            );
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(showStageName == "" //如果没有指定发挥作用的多态
              || showStageName.Equals(FindObjectOfType<IndexRecoder>().stageName))//或者目前就是发挥作用的多态
            //当玩家进入
            isIn = true;//标记自身显示
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //当玩家退出
            isIn = false;
        }
    }
}
