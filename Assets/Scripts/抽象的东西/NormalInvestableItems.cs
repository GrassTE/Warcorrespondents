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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void OnCall()
    {
        Debug.Log("我触发了"+ gameObject.name +"的对话");
        Flowchart.BroadcastFungusMessage("谈论" + itemName);
        //修改玩家操作地图为空，解决玩家在对话时还能移动的问题
        FindObjectOfType<M_Player>().GetComponent<PlayerInput>().SwitchCurrentActionMap("NullMap");
    }
}
