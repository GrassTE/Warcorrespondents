using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class TelephoneLine : Interactive
{
    //电话线类，控制每一处断裂的电话线
    // Start is called before the first frame update
    private float allNeedTime;
    private float hasReparedTime = 0f;
    private bool isReparing = false;
    [SerializeField][ReadOnly]
    private bool isRepared = false;
    IndexRecoder indexRecoder;
    private float process = 0f;
    [Tooltip("特殊电话线用，拖入这个电话线修好后的事件")]
    public Event endEvent;

    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();
        allNeedTime = indexRecoder.TelephoneNeedTime;
        m_interface = GameObject.Find("Canvas").transform.Find("修电话线界面").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRepared&&isReparing)//如果没有修复并且正在修复
        {
            //在修复的话，每帧累计时间，并更新进度
            hasReparedTime += Time.deltaTime;
            process = hasReparedTime/allNeedTime;
            //检查是否满了
            if(process >= 1f)
            {
                isRepared = true;//标记自己已经被修好
                FindObjectOfType<AllLinesInfo>().OKCount++;//找到总线信息，给好了的电话线+1
                Debug.Log("满了，这个修好了");
                OnStopReparing();//关下UI
                GetComponent<SpriteRenderer>().enabled = true;//打开修好的的图片素材
                FindObjectOfType<M_Player>().HasReparedATelephone();//告诉玩家自己被修好，打断修理动画
                if(endEvent != null) endEvent.OnCall();//如果有结束事件，那触发一下结束事件
            }
            //还要更新UI上的进度条
            for(int i = 0; i < m_interface.transform.childCount; i++)
                if(m_interface.transform.GetChild(i).tag == "进度条")               
                    m_interface.transform.GetChild(i).GetComponent<Image>().fillAmount = process;            
        }
    }

    public override void OnCall()
    {  
        //象征着按下交互键了，如果这个还没被修好，即刻开始修复电话线
        if(!isRepared)
        {
            m_interface.SetActive(true);//打开UI
            m_interface.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            StartRepareTheTelephoneLine();
        }
    }

    private void StartRepareTheTelephoneLine()
    {
        isReparing = true;
    }

    public override void StopRepareTheTelephoneLine()
    {
       isReparing = false;
       OnStopReparing();
    }

    //当此电话线修好了
    private void OnStopReparing()
    {
        m_interface.SetActive(false);//关闭修电话线的UI
    }

    public bool HasTheBePrepared(){return isRepared;}
    
    
    //制造一个只读的变量，不要动这些
    public class ReadOnlyAttribute : PropertyAttribute{}
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
    //
}
