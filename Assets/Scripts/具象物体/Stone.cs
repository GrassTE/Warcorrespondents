using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    //具象物体，石头
    [Tooltip("投掷物堆的游戏物体，请拖入预制体。石头被剧情杀炸毁后，将生成这样一个投掷物堆")]
    public GameObject missile;
    //炮弹是触发器，在这里写碰撞没用
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log("被"+other.transform.name+"给锤了");
    //     if(other.transform.tag == "炮弹")//如果被炮弹锤了
    //     {
    //         //因为可能是普通的炮弹锤了这个石头，所以给炮弹加个标识吧，是特殊的炮弹才能炸烂这个石头
    //         if(other.transform.GetComponent<Shell>().AmISpecal())
    //         {
    //             Instantiate(missile,transform.position,Quaternion.identity);//原地生成投掷物堆
    //             Destroy(other.gameObject);
    //             Destroy(gameObject);//被特殊炮弹锤了，销毁炮弹和自己
    //         }
    //         Destroy(other.gameObject);//被锤了以后，销毁那个炮弹
    //     }
    // }

    //如果被特殊炮弹击中
    public void BeHitBySpecalShell()
    {
        Instantiate(missile,transform.position,Quaternion.identity);//原地生成投掷物堆
        Destroy(gameObject);
    }
}
