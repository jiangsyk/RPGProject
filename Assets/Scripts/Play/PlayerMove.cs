using UnityEngine;
using System.Collections;

public enum PlayerState
{
    Moving,
    Idle
}
/*
 * Description: PlayerMove
 * Author:      JiangShu
 * Create Time: 2015/8/17 16:01:57
 */
public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;
    public PlayerState state = PlayerState.Idle;

    private PlayerDirection dir;
    private CharacterController controller;
    void Start()
    {
        dir = GetComponent<PlayerDirection>();
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        float distance = Vector3.Distance(dir.targetPosition, transform.position);
        if (distance > 0.25f)
        {
            state = PlayerState.Moving;
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            state = PlayerState.Idle;
        }
    }
}
