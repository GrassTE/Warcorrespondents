using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //投掷物类，用来控制投掷物
    // Start is called before the first frame update
    private bool amINoisy = false;//记录自己是否落地发出声音的变量
    private bool amIBeenChecked = false;//记录自己是否已经被敌人检查过
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "地面")
        {
            //当投掷物砸到地面，发出一个响声（逻辑上），标记自身为声源
            amINoisy = true;
            //同时，摧毁自身的刚体组件，阻止其滚动
            Destroy(GetComponent<Rigidbody2D>()); 
            //再摧毁自身碰撞体
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

    public bool AMINoisy(){return amINoisy;}
    public bool AmIBeenChecked(){return amIBeenChecked;}
    public void YouAreChecked(){amIBeenChecked = true;}
}
