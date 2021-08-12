using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IndexRecoder : MonoBehaviour
{
    //策划接口类，储存了所有易变的数值，每一项都写了toolTip，谁叫我是小棉袄呢❤对了，电报的字典也写在这里
    // Start is called before the first frame update
    [Tooltip("角色普通移动速度")]
    public float playerMoveSpeed;//角色普通移动速度
    [Tooltip("角色跳跃力度")]
    public float playerJumpSpeed;//角色跳跃力度
    [Tooltip("角色跑步的时候，速度是普通状态的多少倍")]
    public float runSpeedMultiple;//角色跑步的时候，速度是普通状态的多少倍
    [Tooltip("判定输入为点还是横线的界限时间")]
    public float dotRoLineTime;//判定输入为点还是横线的界限时间
    public Dictionary<string, string> codeBook = new Dictionary<string, string>();//摩尔斯电码字典
    [Tooltip("角色修复电话线需要多长时间")]
    public float TelephoneNeedTime;//角色修复电话线需要多长时间
    [Tooltip("炮弹生成的最小时间间隔")]
    public float bombingAreaMinimumTimeInterval;
    [Tooltip("炮弹生成的最大时间间隔")]
    public float bombingAreaMaximumTimeInterval;
    [Tooltip("生成炮弹位置离玩家的最大偏移量")]
    public float bombingAreaMaxOffSetOfShell;
    [Tooltip("生成炮弹的高度")]
    public float bombingAreaShellHeight;
    [Tooltip("炮弹的下落速度")] 
    public float shellSpeed;
    [Tooltip("炮弹的下落时间")] 
    public float shellFallingTime;
    [Tooltip("炮弹阴影的震动幅度")] 
    public float shellShadowRangeOfChange;
    [Tooltip("炮弹阴影的Y值偏移")] 
    public float shellShadowPositionYOffSet;
    [Tooltip("玩家投掷角度变化的速度")] 
    public float rateOfChangeOfThrowingAngle;
    [Tooltip("抛出投掷物的力度")]
    public float strengthOfThrowing;
    [SerializeField][Tooltip("演出名称，这个不给你改，这个是我做多态用的，在这里只读")][ReadOnly]
    public string stageName;
    [Tooltip("CG的淡入淡出时间")]
    public float CGFadeTime;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        //开发者捷径
        codeBook.Add("..--.","864246511");
        codeBook.Add("--..-","02948");
        //
        codeBook.Add(".----","1");
        codeBook.Add("..---","2");
        codeBook.Add("...--","3");
        codeBook.Add("....-","4");
        codeBook.Add(".....","5");
        codeBook.Add("-....","6");
        codeBook.Add("--...","7");
        codeBook.Add("---..","8");
        codeBook.Add("----.","9");
        codeBook.Add("-----","0");

        stageName = "序章-家中-已打码";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //修改演出名称的函数，在游戏流程推进的时候用
    public void ChangeStageName(string newName){stageName = newName;}


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
