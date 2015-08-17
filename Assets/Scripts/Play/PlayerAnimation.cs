using UnityEngine;
using System.Collections;

/*
 * Description: PlayerAnimation
 * Author:      JiangShu
 * Create Time: 2015/8/17 16:12:47
 */
public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove move;
    void Start()
    {
        move = GetComponent<PlayerMove>();
    }
    void LateUpdate()
    {
        if(move.state == PlayerState.Moving)
        {
            PlayAnim("Run");
        }
        else
        {
            PlayAnim("Idle");
        }
    }
    void PlayAnim(string animName)
    {
        animation.CrossFade(animName);
    }
}
