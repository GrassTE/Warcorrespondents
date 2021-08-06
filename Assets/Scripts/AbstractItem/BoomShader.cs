using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BoomShader : MonoBehaviour
{
    //这是控制炸弹爆炸后冲击波产生的脚本，是霄酱写的🤔
    public Material boomMaterial;//爆炸shader的材质
    private Vector2 boomPos;//爆炸坐标
    private bool isBoom = false;//是否爆炸
    // Start is called before the first frame update
    void Start()
    {
        boomMaterial.SetFloat("WaveSpread_Value",0);
        isBoom = true;
        Invoke("setBoom",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoom)
        {
            UpdateBoom();
        }
    }
    
    private void UpdateBoom()
    {
        boomPos = Camera.main.WorldToViewportPoint(new Vector2(transform.position.x, transform.position.y));
        boomMaterial.SetVector("Center",boomPos);
        boomMaterial.SetFloat("WaveSpread_Value",boomMaterial.GetFloat("WaveSpread_Value")+0.2f);
    }

    private void setBoom()
    {
        isBoom = false;
        boomMaterial.SetFloat("WaveSpread_Value",0);
        Destroy(gameObject);
    }

    public void SetboomPos(Vector2 pos)
    {
        this.boomPos = pos;
    }
}
