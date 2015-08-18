using UnityEngine;
using System.Collections;

/*
 * Description: CursorManager
 * Author:      JiangShu
 * Create Time: 2015/8/18 15:10:11
 */
public class CursorManager : MonoBehaviour
{
    public Texture2D cursor_normal;
    public Texture2D cursor_npc_talk;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;

    private Vector2 hotspot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;

    public static CursorManager instance;
    void Start()
    {
        instance = this;
    }
    void Update()
    {

    }

    public void SetNormal()
    {
        Cursor.SetCursor(cursor_normal, hotspot, mode);
    }
    public void SetNpcTalk()
    {
        Cursor.SetCursor(cursor_npc_talk, hotspot, mode);
    }
    public void SetAttack()
    {
        Cursor.SetCursor(cursor_attack, hotspot, mode);
    }
}
