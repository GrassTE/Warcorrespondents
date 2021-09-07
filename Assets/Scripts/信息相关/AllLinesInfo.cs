using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AllLinesInfo : MonoBehaviour
{
    //总线信息类，用来存储场景中电话线断裂的总体信息，
    // Start is called before the first frame update
    [SerializeField]
    private int needCount;
    public int OKCount = 0;
    void Start()
    {
        needCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AreYouOK(){return (needCount == OKCount);}//返回完成量是不是等于需求量

    // //制造一个只读的变量，不要动这些
    // public class ReadOnlyAttribute : PropertyAttribute{}
    // [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    // public class ReadOnlyDrawer : PropertyDrawer
    // {
    //     public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    //     {
    //         return EditorGUI.GetPropertyHeight(property, label, true);
    //     }

    //     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    //     {
    //         GUI.enabled = false;
    //         EditorGUI.PropertyField(position, property, label, true);
    //         GUI.enabled = true;
    //     }
    // }
    // //
}
