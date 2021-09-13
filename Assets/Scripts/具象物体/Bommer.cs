using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bommer : MonoBehaviour
{
    //用来控制机枪手那里的炸弹的代码
    [Tooltip("想要炸弹被点燃后多长时间爆炸？")]
    public float boomTime = 2f;
    [Tooltip("拖入石子")]
    public GameObject realMissile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "投掷物")
        {
            // Invoke("Boom",boomTime);
            StartCoroutine("Boom");
        }
    }

    private IEnumerator Boom()
    {
        yield return new WaitForSeconds(boomTime);
        CinemachineImpulseSource impulseSource;
        impulseSource = GetComponent<CinemachineImpulseSource>();
        impulseSource.GenerateImpulse();
        //播放爆炸音效
        GetComponent<AudioSource>().Play();
        //1.播放自身爆炸动画
        GetComponent<SpriteRenderer>().sortingLayerName = "front";//调整图层上前
        GetComponent<Animator>().SetBool("IsBoom",true);
        yield return new WaitForSeconds(0.3f);
        //2.通知机枪手
        FindObjectOfType<MachineGunner>().BoomerHasBoom();

        FindObjectOfType<M_Player>().missile = realMissile;
    }

    //动画末尾调用
    public void DestroySelf()
    {
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
