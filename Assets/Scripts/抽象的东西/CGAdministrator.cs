using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CGAdministrator : MonoBehaviour
{
    // Start is called before the first frame update
    //CG管理员相关代码

    private RawImage rawImage;
    [Tooltip("记录这个场景中的所有CG，要加的话直接扩容数组，并往新的CG里面加内容")]
    public ACG[] CGs;
    private IndexRecoder indexRecoder;
    void Start()
    {
        rawImage = GetComponent<RawImage>();
        indexRecoder = FindObjectOfType<IndexRecoder>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    //外部呼叫CG用，传入你要调用的CG名
    public　void　CallACG(string CGName)
    {
        //当外面叫了一个CG，传入CG名
        foreach(ACG CG in CGs)
        {
            //找到这个CG
            if(CG.CGName.Equals(CGName))
            {
                Debug.Log("正在显示CG："+CG.name);
                rawImage.texture = CG.texture;//把CG的内容装载上
                rawImage.CrossFadeAlpha(1,indexRecoder.CGFadeTime,true);//淡入显示CG
                Invoke("StopIt",CG.time);
            }
        }
    }

    //改变标记，使管理员意识到CG该停了
    private void StopIt(){rawImage.CrossFadeAlpha(0f,indexRecoder.CGFadeTime,true);}//淡出CG

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
