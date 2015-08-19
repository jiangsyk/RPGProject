using UnityEngine;
using System.Collections;

/*
 * Description: NPC
 * Author:      JiangShu
 * Create Time: 2015/8/18 15:16:24
 */
public class Npc : MonoBehaviour
{
    void OnMouseEnter()
    {
        if(UICamera.hoveredObject == null)
            CursorManager.instance.SetNpcTalk();
    }
    void OnMouseExit()
    {
        if(UICamera.hoveredObject == null)
            CursorManager.instance.SetNormal();
    }
    void OnMouseOver()//移动之上 会每帧调用
    {
        if(UICamera.hoveredObject == null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                //点击
                OnNpcClick();
            }
        }
    }
    protected virtual void OnNpcClick()
    {

    }
}
