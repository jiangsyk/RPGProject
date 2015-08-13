using UnityEngine;
using System.Collections;

/*
 * Description: PressAnyKey
 * Author:      JiangShu
 * Create Time: 2015/8/13 15:58:31
 */
public class PressAnyKey : MonoBehaviour
{
    public GameObject buttonContainer;
    private bool isAnyKeyDown = false;
    private bool isShow = false;
    void Start()
    {

    }
    void Update()
    {
        if( isShow && isAnyKeyDown == false && Input.anyKey)
        {
            //showButtonContainer;
            buttonContainer.SetActive(true);
            isAnyKeyDown = false;
            Destroy(gameObject);
        }
    }
    public void OnShow()
    {
        print("show");
        isShow = true;
    }
}
