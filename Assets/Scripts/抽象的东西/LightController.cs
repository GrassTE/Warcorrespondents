using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    //控制灯光的火焰扰动 霄酱写的
    public Light2D Light2D;
    [Header("光半径")]
    public float radiusCycle;
    public float radiusRate;
    [Header("光强度")]
    public float intensityCycle;
    public float intensityRate;
    private float radiusOrigin;
    private float radiusUpdate;

    private float intensityOrigin;
    private float intensityUpdate;
    // Start is called before the first frame update
    void Start()
    {
        //获取所有数据的初始值
        radiusOrigin = Light2D.pointLightOuterRadius;
        intensityOrigin = Light2D.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        radiusUpdate = radiusOrigin;
        radiusUpdate = radiusCycle * Mathf.Sin(Time.fixedTime * Mathf.PI * radiusRate) + radiusOrigin;//计算简谐震荡后的数值
        Light2D.pointLightOuterRadius = radiusUpdate;

        intensityUpdate = intensityOrigin;
        intensityUpdate = intensityCycle * Mathf.Sin(Time.fixedTime * Mathf.PI * intensityRate) + intensityOrigin;
        Light2D.intensity = intensityUpdate;

    }
}
