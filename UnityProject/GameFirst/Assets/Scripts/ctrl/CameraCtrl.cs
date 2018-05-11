using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

    private Transform player;
    private Vector2 Margin;//相机与角色的相对范围
    private Vector2 smoothing;//相机移动的平滑度
    private BoxCollider2D Bounds;//背景的边界

    private Vector3 m_TargetPosition;

    private Vector3 _min;//边界最大值
    private Vector3 _max;//边界最小值

    public bool IsFollowing { get; set; }//用来判断是否跟随

    // Use this for initialization
    private void Awake()
    {
        
    }
    void Start ()
    {
        Bounds = PrefabFactory.GetGameObject(PrefabFactory.PREFAB + "MapGrid").GetComponent<BoxCollider2D>();
        Margin = new Vector2(0, 0);
        smoothing = new Vector2(3, 3);
        player = PrefabFactory.GetGameObject(PrefabFactory.PREFAB + "player1").transform;
        _min = Bounds.size / 2 * -1; //Bounds.bounds.min;//初始化边界最小值(边界左下角)
        _max = Bounds.size / 2; //Bounds.bounds.max;//初始化边界最大值(边界右上角)
        IsFollowing = true;//默认为跟随
        Update();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    this.transform.LookAt(player);
    //}
    //private void LateUpdate()
    //{
    //    //得到这个目标位置
    //    m_TargetPosition = player.transform.position;
    //    //相机位置
    //    //transform.position = Vector3.Lerp(transform.position, m_TargetPosition, m_Speed * Time.deltaTime);
    //    transform.position = new Vector3(m_TargetPosition.x, m_TargetPosition.y, transform.position.z);
    //    //相机时刻看着人物
    //    //transform.LookAt(playerTransform);

    //}
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        if (IsFollowing)
        {
            if (Mathf.Abs(x - player.position.x) > Margin.x)
            {//如果相机与角色的x轴距离超过了最大范围则将x平滑的移动到目标点的x
                x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
            }
            if (Mathf.Abs(y - player.position.y) > Margin.y)
            {//如果相机与角色的y轴距离超过了最大范围则将x平滑的移动到目标点的y
                y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);
            }
        }
        float orthographicSize = GetComponent<Camera>().orthographicSize;//orthographicSize代表相机(或者称为游戏视窗)竖直方向一半的范围大小,且不随屏幕分辨率变化(水平方向会变)
        var cameraHalfWidth = orthographicSize * ((float)Screen.width / Screen.height);//的到视窗水平方向一半的大小
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);//限定x值
        y = Mathf.Clamp(y, _min.y + orthographicSize, _max.y - orthographicSize);//限定y值
        transform.position = new Vector3(x, y, transform.position.z);//改变相机的位置
    }
}
