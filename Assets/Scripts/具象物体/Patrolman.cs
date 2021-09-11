using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Patrolman : MonoBehaviour
{
    //控制巡逻敌人

    [Tooltip("拖入巡逻点1")]
    public Transform point1;
    [Tooltip("拖入巡逻点2，他将于此两点间往返")]
    public Transform point2;
    [Tooltip("普通移动时的速度")]
    public float walkSpeed;
    [Tooltip("听见响动，冲锋时的速度")]
    public float rushSpeed;
    [SerializeField]
    private float speed;//记录此刻瞬间的速度,不包含方向
    private float velocity;//速度，正值代表向右，用来判断面部朝向
    [SerializeField]
    private Transform target;//当前目标位置
    private bool isInterrupt = false;//记录目前是否被石头落地的声音所吸引
    private float PVelocity = -1f;//记录上一帧的速度,默认上一帧往右走
    private Transform auditoryRange;//听觉范围子物体
    [SerializeField]
    private List<Missile> missiles;//投掷物列表，巡逻者会自动往搜索听觉范围内的投掷物
    private Animator animator;
    public AudioClip[] RunSEs;
    public AudioClip[] walkSEs;
    [Tooltip("请拖入敌人被投掷物吸引后的音效")]
    public AudioClip[] interruptSEs;
    private AudioSource audioPlayer;
    [Tooltip("拖入父级物体")]
    public AudioSource interruptSEPlayer;



    // Start is called before the first frame update
    void Start()
    {
        target = point1;//初始化起始目标为巡逻点1
        speed = walkSpeed;//初始化瞬间速度为走路速度
        auditoryRange = transform.Find("听觉范围");//找到子物体听觉范围
        auditoryRange.gameObject.AddComponent<AuditoryRange>();//给子物体听觉范围填上碰撞监测代码
        missiles = new List<Missile>();//初始化投掷物列表
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalk",true);
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//每帧朝目标移动
        CheckMissiles();//检查是否有投掷物落地
    }

    private int shouldBePlayedWalkSEID = 0;
    public void OnWalkFootTouched()
    {
        //走路动画中脚着地触发
        audioPlayer.clip = walkSEs[shouldBePlayedWalkSEID % walkSEs.Length];
        audioPlayer.volume = 0.2f;
        audioPlayer.Play();
        shouldBePlayedWalkSEID++;
    }
    private int shouldBePlayedRunSEID = 0;
    public void OnRunFootTouched()
    {
        //跑步动画中脚着地触发
        audioPlayer.clip = RunSEs[shouldBePlayedRunSEID % RunSEs.Length];
        audioPlayer.volume = 0.2f;
        audioPlayer.Play();
        shouldBePlayedRunSEID++;

    }


    private void CheckMissiles()
    {
        foreach(Missile missile in missiles)
        {
            //Debug.Log(missile.AMINoisy());
            if(missile.AMINoisy() && !missile.AmIBeenChecked())//如果投掷物在发声、且没有被检查过
            {
                Debug.Log("听见了");
                //将目标位置设定为落点
                target = missile.transform;
                //更改速度为跑步速度
                speed = rushSpeed;
                //标记该投掷物已被检查
                missile.YouAreChecked();
                isInterrupt = true;
                PVelocity = 0;

                //执行听见动画
                animator.SetBool("IsListen",true);
                StartCoroutine("StopListen");//取消听见动画条件
                //播放听见音效
                interruptSEPlayer.clip = interruptSEs[(int)Random.Range(0,interruptSEs.Length)];
                interruptSEPlayer.volume = 0.5f;
                interruptSEPlayer.Play();
            }
        }
    }

    private IEnumerator StopListen()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsListen",false);
        animator.SetBool("IsRush",true);//开启跑步条件
        animator.SetBool("IsWalk",true);//关闭走路条件
    }

    //朝目标移动函数
    private void Move()
    {
        //构造速度向量
        velocity = (target.position - transform.position).x;
        velocity = Mathf.Abs(velocity)/velocity;//把速度标准化为1或者-1，只保留方向
        velocity *= speed;//给速度赋以大小

        //判断是否到达巡逻点或者落点
        //Debug.Log(velocity*PVelocity);
        if(velocity*PVelocity < 0)//速度相乘得负数，说明方向发生改变
        {
            //如果计算速度发生改变，且不是因为被石头打断，说明经过了巡逻点，此时更换目标点为另一个
            if(target.Equals(point1) && !isInterrupt) target = point2;
            else if(target.Equals(point2) && !isInterrupt) target = point1;//不是被投掷物吸引的时候，才这样

            //如果目标是投掷物的落点，恢复速度和目标点
            if(target.gameObject.tag == "投掷物")
            {
                speed = walkSpeed;
                //target = point2;
                if(velocity > 0) target = point2;
                else target = point1;
                Debug.Log("投掷物触发转向");
                isInterrupt = false;
                
                //动画
                animator.SetBool("IsCheck",true);
                animator.SetBool("IsWalk",true);
                animator.SetBool("IsRush",false);
                StartCoroutine("StopCheckAnimation");
            }
        }

        //控制面部朝向
        if(velocity > 0) transform.rotation = Quaternion.Euler(0,0,0);
        else transform.rotation = Quaternion.Euler(0,180f,0);

        // //移动（改用动画移动）
        // transform.position = new Vector3(
        //     //x
        //     transform.position.x +//自身此刻位置 加上
        //     velocity * //构造好的速度乘以
        //     Time.deltaTime,//使其与时间无关
            
        //     //y和z不变
        //     transform.position.y,
        //     transform.position.z
        // );

        //更新PVelocity
        PVelocity = velocity;

    }

    private IEnumerator StopCheckAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("IsCheck",false);
    }

    //开枪动画中调用，告诉玩家你被射死了
    public void OnShoot()
    {
        //FindObjectOfType<M_Player>().YouAreShooting();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!other.GetComponent<M_Player>().AreYouCovered())
            {
                animator.SetBool("IsFire",true);
            }
        }
    }

    //在听觉范围中调用，加入一个监听中的投掷物
    public void AddAMissile(Missile missile){missiles.Add(missile);}
    //在听觉范围中调用，移除一个监听中的投掷物
    public void RemoveAMissile(Missile missile){missiles.Remove(missile);}

    public void ChangeTargetTo(Transform newTarget)
    {
        target = newTarget;
    }



    private class AuditoryRange : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "投掷物")
            {
                //当有投掷物进入听觉范围，把他加入监控内的投掷物列表
                GetComponentInParent<Patrolman>().AddAMissile(other.GetComponent<Missile>());
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == "投掷物")
            {
                //当有投掷物离开听觉范围，把他移出监控内的投掷物列表
                GetComponentInParent<Patrolman>().RemoveAMissile(other.GetComponent<Missile>());
            }
        }
    }

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
