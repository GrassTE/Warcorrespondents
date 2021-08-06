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
    
    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();
        shellSpeed = indexRecoder.shellSpeed;
        fallingTime = indexRecoder.shellFallingTime;
        ground = GameObject.FindWithTag("地面").transform;
        m_shadow = Instantiate(shadow,//生成一片阴影
                                new Vector3(transform.position.x,//在这枚炮弹的X
                                            ground.transform.position.y + //地面的Y
                                                indexRecoder.shellShadowPositionYOffSet,//加上偏移量
                                            0),
                                Quaternion.identity)
                                .transform;
        Invoke("Drop",fallingTime);
    }

    // Update is called once per frame
    void Update()
    {
        ShadowShock();
        if(isDroping)
        {
            transform.position -= new Vector3(0,shellSpeed*Time.deltaTime,0);
        }

        
    }

    private void ShadowShock()
    {
        m_shadow.transform.localScale = new Vector3(m_shadow.localScale.x +
                                                    Random.Range(-indexRecoder.shellShadowRangeOfChange,
                                                                indexRecoder.shellShadowRangeOfChange),
                                                    m_shadow.localScale.y,
                                                    m_shadow.localScale.z);
    }

    private void Drop()
    {
        isDroping = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        //当玩家被炮弹击中
        switch (other.tag)
        {
            case "Player":
                //玩家被炮弹击中
                break;
            case "地面":
                Destroy(m_shadow.gameObject);
                Destroy(gameObject);
                Instantiate(boomObj, new Vector2(transform.position.x, transform.position.y),Quaternion.identity);
                break;
        }
    }
    

}
