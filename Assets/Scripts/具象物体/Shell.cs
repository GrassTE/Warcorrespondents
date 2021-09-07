using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //炮弹类，控制轰炸区内的炮弹和炮弹的阴影🎇
    // Start is called before the first frame update
    public GameObject shadow;//阴影游戏物体
    private Transform ground;//地面的位置信息
    private float shellSpeed;//炮弹速度
    private IndexRecoder indexRecoder;
    private float fallingTime;
    private bool isDroping = false;
    private Transform m_shadow;
    public GameObject boomObj;
    public BombingArea M_BombingArea;
    private bool amISpecal = false;//记录自己是不是特殊的的变量。特殊的炮弹才能炸烂石头。
    private Animator animator;
    private delegate float BuildAFitX(float deleta);
    [Tooltip("请填入阴影的最大值")]
    public float MaxShadowSize;
    [Tooltip("请填入阴影的最小值")]
    public float MinShadowSize;
    public Animator target;//如果是特殊炮弹，则有targe这个变量，当这个炮弹爆炸，触发目标的死亡动画
    
    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();
        shellSpeed = indexRecoder.shellSpeed;
        fallingTime = indexRecoder.shellFallingTime;
        ground = GameObject.FindWithTag("地面").transform;
        if(!amISpecal)//特殊炮弹不予阴影
        {
            m_shadow = Instantiate(shadow,//生成一片阴影
                                    new Vector3(transform.position.x,//在这枚炮弹的X
                                                ground.transform.position.y + //地面的Y
                                                M_BombingArea.shellShadowYOffset,//加上偏移量
                                                0),
                                    Quaternion.identity)
                                    .transform;
        }
        Invoke("Drop",fallingTime);
        Invoke("DestroySelf",10f);

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_shadow != null) ShadowShock();
        if(isDroping)
        {
            transform.position -= new Vector3(0,shellSpeed*Time.deltaTime,0);
        }

        
    }
    public bool AmISpecal(){return amISpecal;}//外部调用，返回这个炮弹是不是特殊的
    public void YouAreSpecal(){amISpecal = true;}//外部调用，生成炮弹时，给其标记它是特殊的。

    //控制阴影变化的函数，每帧调用一次
    private void ShadowShock()
    {
        //首先构造一个本帧变化x
        BuildAFitX buildAFitX = (float deleta)
        =>
        {
            float newX = m_shadow.transform.localScale.x + deleta;
            if(newX > MinShadowSize && newX < MaxShadowSize)
            {return newX;}
            else return m_shadow.transform.localScale.x;
        };
        float x = buildAFitX(Random.Range(-indexRecoder.shellShadowRangeOfChange, 
                                          indexRecoder.shellShadowRangeOfChange));
        //使得本地大小改变为
        m_shadow.transform.localScale = new Vector3(
                                                    //x
                                                    // m_shadow.localScale.x +
                                                    // Random.Range(-indexRecoder.shellShadowRangeOfChange,
                                                    //             indexRecoder.shellShadowRangeOfChange),
                                                    x
                                                    ,
                                                    //y，z不变
                                                    m_shadow.localScale.y,
                                                    m_shadow.localScale.z);
    }

    private void Drop()
    {
        isDroping = true;
    }

    public void DestroySelf()
    {
        //动画中调用，爆炸动画结束后删除自身和阴影
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        //当炮弹爆炸，根据目标物体的tag分化
        switch (other.tag)
        {
            case "Player":
                //玩家被炮弹击中
                Debug.Log("玩家被炮弹击中");
                break;
            case "地面":
                //Destroy(m_shadow.gameObject);
                //Destroy(gameObject);
                Instantiate(boomObj, new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
                animator.SetBool("IsBoom",true);
                if(m_shadow != null) Destroy(m_shadow.gameObject);
                isDroping = false;
                break;
            case "石头":
                // Destroy(m_shadow.gameObject);
                // Destroy(gameObject);//摧毁炮弹
                animator.SetBool("IsBoom",true);
                //Destroy(m_shadow.gameObject);
                isDroping = false;
                //如果自己是特殊的炮弹，则触发石头的程序段
                if(amISpecal) other.GetComponent<Stone>().BeHitBySpecalShell();
                break;
            case "老兵":
                animator.SetBool("IsBoom",true);
                isDroping = false;
                other.transform.Find("老兵").GetComponent<Animator>().SetBool("IsBoomDead",true);//执行老兵被炸死动画
                break;
            // case "电报机":
            //     animator.SetBool("IsBoom",true);
            //     isDroping = false;//播放爆炸动画
            //     FindObjectOfType<M_Player>().GetComponent<Animator>().
            //     SetBool("IsBoomDead",true);//播放玩家被炸死动画
            //     FindObjectOfType<AfterCoding>().OnDeadAnimation();
            //     break;
            case "爆炸点":
                animator.SetBool("IsBoom",true);
                isDroping = false;//播放爆炸动画
                FindObjectOfType<AfterCoding>().OnDeadAnimation();
                break;
        }
        if(amISpecal)
        {
            if(target!=null)target.SetBool("IsBoomDead",true);
        }
    }
    

}