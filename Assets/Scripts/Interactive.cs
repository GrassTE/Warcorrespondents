using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_interface;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<M_Player>().catched = this;
        }
    }

   void  OnTriggerExit2D(Collider2D other)
   {
       if(other.tag == "Player")
        {
            other.GetComponent<M_Player>().catched = null;
        }
   }

    public void ShowInfo()
    {
        m_interface.SetActive(true);
    }

    public virtual void Coding(string temp){}
}
