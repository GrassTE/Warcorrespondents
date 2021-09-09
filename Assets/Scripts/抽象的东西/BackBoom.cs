using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackBoom : MonoBehaviour
{
    public Transform left;

    public Transform right;
    public Transform up;

    public Transform down;

    public GameObject boomLight;

    public List<GameObject> BoomList;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("AddLight",1f,0.2f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddLight()
    {
        Vector2 pos = new Vector2(Random.Range(left.position.x,right.position.x),Random.Range(up.position.y,down.position.y));
        Instantiate(boomLight, pos, Quaternion.identity);
    }
    
}
