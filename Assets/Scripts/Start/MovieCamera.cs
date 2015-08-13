using UnityEngine;
using System.Collections;

/*
 * Description: MovieCamera
 * Author:      JiangShu
 * Create Time: 2015/8/13 15:07:07
 */
public class MovieCamera : MonoBehaviour
{
    public float speed = 10;
    private float endZ = -20;
    void Start()
    {

    }
    void Update()
    {
        if(transform.position.z < endZ)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
