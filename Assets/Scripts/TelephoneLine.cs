using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneLine : Interactive
{
    // Start is called before the first frame update
    private float allNeedTime;
    private float hasReparedTime = 0f;
    private bool isReparing = false;
    public bool isRepared = false;
    IndexRecoder indexRecoder;
    private float process = 0f;

    void Start()
    {
        indexRecoder = FindObjectOfType<IndexRecoder>();
        allNeedTime = indexRecoder.TelephoneNeedTime;
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
                isRepared = true;
                FindObjectOfType<AllLinesInfo>().OKCount++;
                Debug.Log("满了，这个修好了");
                OnStopReparing();
            }
            //还要更新UI上的进度条
            for(int i = 0; i < m_interface.transform.childCount; i++)
                if(m_interface.transform.GetChild(i).tag == "进度条")               
                    m_interface.transform.GetChild(i).GetComponent<Image>().fillAmount = process;            
        }
    }

    public override void OnCall()
    {  
        //象征着按下交互键了，如果这个还没被修改，即刻开始修复电话线
        if(!isRepared)
        {
            m_interface.SetActive(true);  
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

    private void OnStopReparing()
    {
        m_interface.SetActive(false);
    }
}
