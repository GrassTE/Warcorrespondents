using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolymorphicAdministrator : MonoBehaviour
{
    // Start is called before the first frame update
    //多态管理员，旨在对同一个场景进行不同的初始化，以节省空间
    private IndexRecoder indexRecoder;//记录者物体
    [Tooltip("多态管理员，此参数记录着“这个场景有几种状态，这几个状态的名称分别是什么”，这样的信息，请键入不同的演出名")]
    public string[] statesNames;

    [Tooltip("多态管理员，此参数记录着“当场景为此状态时，应该执行怎样的初始化呢？”这样的信息，请拖入事件")]
    public Event[] statesEvents;
    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();//找到记录者物体
        TransfromToAState();
    }

    //初始化为某个多态中的一种，根据是记录者中的演出名
    private void TransfromToAState()
    {
        for(int i = 0; i < statesNames.Length; i++)
        {
            //遍历每一种多态名
            if(indexRecoder.stageName.Equals(statesNames[i]))//如果是第i种多态
            {
                try
                {
                    statesEvents[i].OnCall();//则执行对应事件进行场景的初始化
                }
                catch(System.NullReferenceException e)
                {
                    Debug.Log("此多态没有被赋予事件，可能是场景本身初始状态就是多态中的一种，所以不需要初始化");
                    e.ToString();
                }
            }
        }
    }

}
