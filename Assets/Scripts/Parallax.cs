using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    更新日期2021.7.24 视差类
    使用方式：将类挂载到需要视差的背景上，将主摄像机赋值给Cam，调节视差率即可
    注意 移动的背景一定要比不移动的面积大
*/
public class Parallax : MonoBehaviour
{

    public Transform Cam;//视差摄像机
    public float moveRate;//视差率
    private float startPoint;//起点，自动获取
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position.x;//获取当前起点位置
    }

    // Update is called once per frame
    void Update()
    {
        //每帧更新位置
        transform.position = new Vector2(startPoint + Cam.position.x * moveRate, transform.position.y);
    }
}
