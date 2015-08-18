using UnityEngine;
using System.Collections;

/*
 * Description: PlayerDirection
 * Author:      JiangShu
 * Create Time: 2015/8/17 15:39:21
 */
public class PlayerDirection : MonoBehaviour
{
    public GameObject effect_click_prefab;
    public Vector3 targetPosition;

    private bool isMoving = false;//鼠标是否按下

    private PlayerMove move;
    void Start()
    {
        targetPosition = transform.position;
        move = GetComponent<PlayerMove>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && UICamera.hoveredObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray,out hitInfo);
            if(isCollider && hitInfo.collider.tag == Tags.ground)
            {
                isMoving = true;
                //点击效果
                ShowClickEffect(hitInfo.point);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if(isMoving)
        {
            //得到目标位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray,out hitInfo);
            if(isCollider && hitInfo.collider.tag == Tags.ground)
            {
                //转向
                LookAtTarget(hitInfo.point);
            }
        }
        else
        {
            if(move.state == PlayerState.Moving)
            {
                LookAtTarget(targetPosition);
            }
        }
    }
    //实例化点击效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        Vector3 showPos = hitPoint;
        showPos.y += 0.1f;
        GameObject.Instantiate(effect_click_prefab, showPos, Quaternion.identity);
    }
    //让主角朝向目标位置
    void LookAtTarget(Vector3 hitPos)
    {
        targetPosition = hitPos;
        targetPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);//保证Y一致
        transform.LookAt(targetPosition);
    }
}
