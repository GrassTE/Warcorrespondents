using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    // Start is called before the first frame update
    //这是所有可交互物体的基类
    public GameObject m_interface;//可交互物体一般都和一个UI界面挂钩，这就是那个UI界面

    //这是一对碰撞检测代码。当玩家进入，将自身传给玩家。当玩家退出，把玩家的catch清空
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<M_Player>().catched = this;
        }
    }
   void  OnTriggerExit2D(Collider2D other)
   {
       if(other.tag == "Player")
        {
            other.GetComponent<M_Player>().catched = null;
        }
   }
   //

    //当这个可交互物体被玩家交互。一般需要重写这个函数。
    public virtual void OnCall(){}
    //

    //以下为针对各具体可交互对象的虚拟函数，在具体物体中重写
    public virtual void Coding(string temp){}
    public virtual void StopRepareTheTelephoneLine(){}
    //
}