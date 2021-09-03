using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStage2 : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine("OpenReadyMachine");
    }

    private IEnumerator OpenReadyMachine()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<AReadyMachine>().GetComponent<BoxCollider2D>().enabled = true;//打开损坏电报机的碰撞体
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
