using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenTheConversationAfterRecollectionIsCompleted : Event
{
    //事件：当完成回忆后的对话后
    public override void OnCall()
    {
        //此时按照剧本，应该弹出一段CG，字幕【第二天】　－＞　父亲渐行渐远动画　－＞　字幕【一段时间后】
        FindObjectOfType<CGAdministrator>().CallACG("暂用");
    }
}
