using UnityEngine;
using System.Collections;

/*
 * Description: FunctionBar
 * Author:      JiangShu
 * Create Time: 2015/8/18 15:32:09
 */
public class FunctionBar : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Inventory.instance.GetId(Random.Range(1001, 1004));
        }
    }
    public void OnStatusBtnClick()
    {

    }
    public void OnBagBtnClick()
    {
        Inventory.instance.TransformShowState();
    }
    public void OnEquipBtnClick()
    {

    }
    public void OnSkillBtnClick()
    {

    }
    public void OnSettingBtnClick()
    {

    }
}
