using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //投掷物类，用来控制投掷物
    // Start is called before the first frame update
    [SerializeField]
    private bool amINoisy = false;//记录自己是否落地发出声音的变量
    private bool amIBeenChecked = false;//记录自己是否已经被敌人检查过
    private Rigidbody2D m_rigidbody;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //使得自身旋转角度匹配速度，像一支箭矢
        if(m_rigidbody != null)
        {
            float angle = Vector2.Angle(m_rigidbody.velocity,Vector2.right);
            if(m_rigidbody.velocity.y > 0)  m_rigidbody.SetRotation(angle);
            else m_rigidbody.SetRotation(-angle);
        }
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
            //Destroy(GetComponent<CapsuleCollider2D>());
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            //播放着地音效
            GetComponent<AudioSource>().Play();
        }
    }

    public bool AMINoisy(){return amINoisy;}
    public bool AmIBeenChecked(){return amIBeenChecked;}
    public void YouAreChecked(){amIBeenChecked = true;}
}
