using UnityEngine;
using System.Collections;

/*
 * Description: InventoryDes
 * Author:      JiangShu
 * Create Time: 2015/8/19 16:33:50
 */
public class InventoryDes : MonoBehaviour
{
    public static InventoryDes instance;

    private UILabel label;
    void Awake()
    {
        instance = this;
        label = GetComponentInChildren<UILabel>();
        gameObject.SetActive(false);
    }
    void Start()
    {

    }
    void Update()
    {

    }
    public void Show(int id)
    {
        gameObject.SetActive(true);

        transform.position = UICamera.currentCamera.ScreenToWorldPoint(Input.mousePosition);

        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoByID(id);
        string des = "";
        switch( info.type )
        {
            case ObjectType.Drug:
                des = GetDrugDes(info);
                break;
        }
        label.text = des;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    string GetDrugDes(ObjectInfo info)
    {
        string des = "";
        des += "名称：" + info.name + "\n";
        des += "+HP：" + info.hp + "\n";
        des += "+MP：" + info.mp + "\n";
        des += "出售价：" + info.sellPrice + "\n";
        des += "购买价：" + info.buyPrice + "\n";
        return des;
    }
}
