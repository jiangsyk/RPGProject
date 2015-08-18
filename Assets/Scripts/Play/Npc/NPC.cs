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
        CursorManager.instance.SetNpcTalk();
    }
    void OnMouseExit()
    {
        CursorManager.instance.SetNormal();
    }
}
