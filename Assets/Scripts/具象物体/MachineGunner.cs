using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunner : MonoBehaviour
{
    //机枪手类，控制检测前方一片区域的敌人
    // Start is called before the first frame update
    private bool hasBeHit = false;//是否已被打中
    private Animator person;
    private Animator gun;//声明两个部件的动画组件
    private Animator groundFireAnimation;
    private Animator groundFireAnimation2;
    private Animator gunFireAnimation;
    [Tooltip("请拖入第二个上坑点的游戏物体，将在敌人被击晕后激活这个上坑点")]
    public GameObject UpPoint2;

    public AudioSource gunnerAudio;//获取机枪音效


    void Start()
    {
        person = transform.Find("敌人").GetComponent<Animator>();
        gun = transform.Find("机枪").GetComponent<Animator>();
        groundFireAnimation = transform.Find("地面枪光").GetComponent<Animator>();
        groundFireAnimation2 = transform.Find("地面枪光2").GetComponent<Animator>();
        gunFireAnimation = transform.Find("枪口枪光").GetComponent<Animator>();//找到部件的动画组件
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //触发器是敌人的前方监测区域，当玩家进入检测区域，机枪手进入射击状态，目前用变红表示
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !hasBeHit)//同时需要满足未被击中这个条件
        {
            //GetComponent<SpriteRenderer>().color = Color.red;
            //播放开火动画
            person.SetBool("IsFiring",true);
            gun.SetBool("IsFiring",true);
            groundFireAnimation.SetBool("IsFiring",true);
            groundFireAnimation2.SetBool("IsFiring",true);
            gunFireAnimation.SetBool("IsFiring",true);
        }
    }
    //当玩家退出检测区域，停止射击状态,变为通常状态，现在用白色表示
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //GetComponent<SpriteRenderer>().color = Color.white;
            //关闭开火动画
            person.SetBool("IsFiring",false);
            gun.SetBool("IsFiring",false);
            groundFireAnimation.SetBool("IsFiring",false);
            groundFireAnimation2.SetBool("IsFiring",false);
            gunFireAnimation.SetBool("IsFiring",false);
        }
    }
    //碰撞体是机枪手自身的碰撞体，如果被投掷物砸中，则陷入昏迷状态，目前用绿色表示
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "投掷物")
        {
            gunnerAudio.Stop();//关闭音效
            hasBeHit = true;//标记自身已被击中
            //关闭开火动画
            gun.SetBool("IsFiring",false);
            groundFireAnimation.SetBool("IsFiring",false);
            groundFireAnimation2.SetBool("IsFiring",false);
            gunFireAnimation.SetBool("IsFiring",false);
            //播放死亡动画
            person.SetBool("IsDead",true);
            //把上坑点2激活
            UpPoint2.SetActive(true);
            //关闭自身碰撞体
            foreach(BoxCollider2D collider in GetComponents<BoxCollider2D>())
            {
                collider.enabled = false;
            }
        }
    }
    
    public bool AreYouOK(){return !hasBeHit;}//返回机枪手状态是否良好，如果被打，则返回状态不好

}
