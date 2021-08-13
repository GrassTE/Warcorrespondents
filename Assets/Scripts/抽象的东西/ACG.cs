using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //写一个类，代表一个CG，里面保存CG需要的内容
    public class ACG : MonoBehaviour
    {
        [Tooltip("名字，同时也是唯一调用标识，别吐槽我用中文，这里是中国")]
        public string CGName;
        [Tooltip("这个CG要显示的东西，据说视频也可以？")]
        public Texture texture;
        [Tooltip("这个CG要显示多长时间")]
        public float time;
        [Tooltip("CG播放结束时要触发什么事件？")]
        public Event onEnded;

        public void OnEnded(){onEnded.OnCall();}//触发结束事件，不同CG事件不一样，所以用public自己拖
    }

