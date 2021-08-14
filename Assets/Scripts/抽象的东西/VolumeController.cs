using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeController : MonoBehaviour
{
    //屏幕后处理控制 霄酱写的
    public VolumeProfile VolumeProfile;

    private List<VolumeComponent> VolumeComponents;
    public float Cycle;
    public float rate;

    private float origin;
    private float update;
    
    // Start is called before the first frame update
    void Start()
    {
        VolumeComponents = VolumeProfile.components;
        origin = VolumeComponents[0].parameters[1].GetValue<float>();

    }

    // Update is called once per frame
    void Update()
    {
        update = origin;
        update = Cycle * Mathf.Sin(Time.fixedTime * Mathf.PI * rate) + origin;
        VolumeComponents[0].parameters[1].SetValue(new FloatParameter(update));
    }
}
