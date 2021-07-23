using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //看看进来的是个啥
        switch(other.tag)
        {
            case "Player"://如果是玩家，后续填写死亡
                Debug.Log("玩家踩到地雷了");
                break;
            case "投掷物"://如果是投掷物，销毁投掷物和自己
                Debug.Log("投掷物砸到地雷了");
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
        }
    }
}
