using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    //具象物体，石头
    [Tooltip("投掷物堆的游戏物体，请拖入预制体。石头被剧情杀炸毁后，将生成这样一个投掷物堆")]
    public GameObject missile;
    private delegate Vector3 Down(Vector3 pos);
    [Tooltip("由此石块生成的投掷物堆需要一个触发时事件，在这里给其赋值")]
    public Event heapOnCallEvent;


    //如果被特殊炮弹击中
    public void BeHitBySpecalShell()
    {
        Down down = (Vector3 pos) 
        =>
        {
            return new Vector3(
                //x
                pos.x,
                //y
                pos.y - 0.6f,
                //z
                pos.z
            );
        };
        MissileHeap heap = Instantiate(missile,
                    down(transform.position),
                    Quaternion.identity).GetComponent<MissileHeap>();//原地生成投掷物堆，并获取其投掷物堆控制组件
        heap.srengthOfThrowing = 15;//修改生成投掷物堆的力度
        heap.OnCallEvent = heapOnCallEvent;
        heap.gameObject.tag = "投掷物堆";
        Destroy(gameObject);
    }
}
