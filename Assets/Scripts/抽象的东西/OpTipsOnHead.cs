using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpTipsOnHead : OperationsInfo
{
    private M_Player player;
    private Transform point;//显示这个提示的点位，在玩家的头上。为了避免转向问题所以稍微绕了一点
    private IndexRecoder indexRecoder;
    void Start()
    {
        player = FindObjectOfType<M_Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        point = player.transform.Find("头顶提示点位");
        indexRecoder = FindObjectOfType<IndexRecoder>();
    }

    void Update()
    {
        CheckPlayerCatchedAndRun();
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

        transform.position = point.position;
    }
    private void CheckPlayerCatchedAndRun()
    {
        if(player.catched != null)
        {
            switch(player.catched.gameObject.tag)
            {
                case "门":
                    if(indexRecoder.stageName == "开门演出" || indexRecoder.stageName == "准备出发")
                    isIn = true;
                    break;
                case "镜子":
                    if(indexRecoder.stageName != "准备出发")
                    isIn = true;
                    break;
                case "水缸":
                    isIn = true;
                    break;
                case "父亲":
                    isIn = true;
                    break;
                case "电话线":
                    TelephoneLine telephoneLine = (TelephoneLine)player.catched;
                    if(!telephoneLine.HasTheBePrepared())
                    {
                        isIn = true;
                    }
                    else
                    isIn = false;
                    break;
                case "电报机":
                    isIn = true;
                    break;
                case "地图":
                    isIn = true;
                    break;
                case "任务书":
                    isIn = true;
                    break;
                case "投掷物堆":
                    isIn = true;
                    break;
                default:
                    isIn = false;
                    break;
            }
        }
        else isIn = false;
    }


}
