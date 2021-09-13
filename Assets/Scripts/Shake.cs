using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{


    public float shakeAmount = 0.05f; //振幅
    public bool is_shake;
    Vector3 first_pos;

    private void Start()
    {
        first_pos = this.transform.localPosition;
    }

    public void StartShake()
    {
        //if (is_shake) return;
        is_shake = true;
    }

    public void Update()
    {
        if (!is_shake) return;
        Vector3 pos = first_pos + Random.insideUnitSphere * shakeAmount;
        pos.y = transform.localPosition.y;
        transform.localPosition = pos;
    }

    public void EndShake()
    {
        is_shake = false;
        first_pos.y = transform.localPosition.y;
        transform.localPosition = first_pos;
    }

}