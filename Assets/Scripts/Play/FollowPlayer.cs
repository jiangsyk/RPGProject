using UnityEngine;
using System.Collections;

/*
 * Description: FollowPlayer
 * Author:      JiangShu
 * Create Time: 2015/8/17 16:48:02
 */
public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetPosition;//偏移

    public float distance = 0;
    public float scrollSpeed = 10;
    public float rotateSpeed = 1f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player);
        offsetPosition = transform.position - player.position;
    }
    void Update()
    {
        transform.position = player.position + offsetPosition;
        ScrollView();//滑轮拉动视野
        RotateView();//处理视野旋转
    }

    void ScrollView()
    {
        //向后返回负值  向前滑动返回正值（拉近视野）
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 18);
        offsetPosition = offsetPosition.normalized * distance;
    }
    void RotateView()
    {
    //    Input.GetAxis("Mouse X");//鼠标在水平方向的滑动
    //    Input.GetAxis("Mouse Y");//鼠标在垂直方向的滑动

/*        if(Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if(isRotating)
        {

        }
        */
        if(Input.GetMouseButton(1))
        {
            transform.RotateAround(player.position,player.up,rotateSpeed * Input.GetAxis("Mouse X"));//围绕Y旋转

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;
            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));//上下旋转，影响有2个 position,rotation
            

            //限制旋转角度,超出之后旋转无效
            float x = transform.eulerAngles.x;
            if(x < 10 || x > 80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
            offsetPosition = transform.position - player.position;
        }

    }
}
