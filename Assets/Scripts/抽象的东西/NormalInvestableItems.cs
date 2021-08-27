using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;

public class NormalInvestableItems : Interactive
{
    // Start is called before the first frame update
    //普通可调查对象的类，用在按F可以触发调查对话的对象上💬
    public string itemName;
    private bool isMoving = false;

    //水缸才用得上，基类里写这个，属于屎山代码
    private Transform watertank;
    private Vector3 target; 
    //
    void Start()
    {
        target = new Vector3(1.92999995f,-1.37871194f,0);
        try
        {
            watertank = GameObject.Find("水缸").transform;
        }
        catch(System.Exception){}
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) watertank.position += (target - watertank.position)*
                                            Time.deltaTime*
                                            1f;
    }

    public override void OnCall()
    {
        if(itemName == "准备出发时的水缸")
        {
            //这项比较特殊，只能这样单独写了，我有罪，这是屎山代码
            isMoving = true;
            FindObjectOfType<AReadyMachine>().m_Collider.enabled = true;
        }
        else
        {
            Debug.Log("我触发了"+ gameObject.name +"的对话");
            Flowchart.BroadcastFungusMessage("谈论" + itemName);
            //修改玩家操作地图为空，解决玩家在对话时还能移动的问题
            FindObjectOfType<M_Player>().GetComponent<PlayerInput>().SwitchCurrentActionMap("NullMap");
        }
        
    }

    //返回水缸的运动状态
    public bool CheckMoving(){return isMoving;}
}
