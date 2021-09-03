using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    //地雷系统的地雷类，因为系统还十分不完善，所以没有什么内容🥔
    private Animator animator;

    public AudioSource boomAudio;//地雷爆炸音效
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //爆炸动画结束后调用，销毁自己
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //看看进来的是个啥
        switch(other.tag)
        {
            case "Player"://如果是玩家，后续填写死亡
                Debug.Log("玩家踩到地雷了");
                animator.SetBool("IsBoom",true);
                boomAudio.Play();
                break;
            case "投掷物"://如果是投掷物，销毁投掷物和自己
                Debug.Log("投掷物砸到地雷了");
                Destroy(other.gameObject);
                animator.SetBool("IsBoom",true);
                boomAudio.Play();
                break;
        }
    }
}
