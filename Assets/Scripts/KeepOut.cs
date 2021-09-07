using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOut : MonoBehaviour
{
    public List<GameObject> playerLayer;//获得所有玩家的图层 没办法 我只会这么写了 屎山代码
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //当玩家进入这个遮挡区域 把图层换为遮光的图层
        if (other.tag == "Player")
        {
            for (int i = 0; i < playerLayer.Count; i++)
            {
                playerLayer[i].GetComponent<SpriteRenderer>().sortingLayerName = "player（遮光）";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //当玩家出去这个遮挡区域 把图层换回去
        if (other.tag == "Player")
        {
            for (int i = 0; i < playerLayer.Count; i++)
            {
                playerLayer[i].GetComponent<SpriteRenderer>().sortingLayerName = "player";
            }
        }
    }

    
}
