using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombingArea : MonoBehaviour
{
    //这是轰炸区的脚本，控制轰炸区相关的所有逻辑💣
    // Start is called before the first frame update
    private bool bombing = false;//是否正在轰炸
    public GameObject shell;//炮弹游戏物体
    // [Tooltip("炮弹阴影Y轴的偏移量")]
    // public float shellShadowYOffset;//炮弹阴影Y轴的偏移量，因为复杂原因，必须使用此变量调整阴影的Y位置

    private float minimumTimeInterval;
    private float maximumTimeInterval;//生成炮弹的最小和最大时间间隔

    private float maxOffSetOfShell;//生成炮弹离玩家的最大偏移量
    private float leftTime = 0f;
    private IndexRecoder indexRecoder;
    private M_Player player;
    private float shellHeight;

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(bombing) Bomb();
    }

    private void Init()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();
        minimumTimeInterval = indexRecoder.bombingAreaMinimumTimeInterval;
        maximumTimeInterval = indexRecoder.bombingAreaMaximumTimeInterval;
        maxOffSetOfShell = indexRecoder.bombingAreaMaxOffSetOfShell;
        shellHeight = indexRecoder.bombingAreaShellHeight;
        player = FindObjectOfType<M_Player>();
    }


    private void Bomb()
    {
        if(leftTime <= 0f)
        {
            Instantiate(shell,//生成炮弹
                        player.transform.position +  //以玩家位置
                        new Vector3(Random.Range(-maxOffSetOfShell,maxOffSetOfShell),//加上水平方向的偏移量
                                                shellHeight,0),//竖直方向给高度
                        Quaternion.identity);
            leftTime = Random.Range(minimumTimeInterval,maximumTimeInterval);
        }
        else leftTime -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")//当玩家进入轰炸区
        {
            bombing = true;
        }
    }

    void  OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")//当玩家退出轰炸区
        {
            bombing = false;
        }
    }
}
