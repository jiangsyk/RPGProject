using UnityEngine;
using System.Collections;

/*
 * Description: InventoryItemGrid
 * Author:      JiangShu
 * Create Time: 2015/8/19 10:26:47
 */
public class InventoryItemGrid : MonoBehaviour
{
    private int id = 0;
    private int num = 0;
    private ObjectInfo info = null;

    private UILabel numLabel;

    void Awake()
    {
        numLabel = GetComponentInChildren<UILabel>();
        numLabel.gameObject.SetActive(false);
    }
    void Update()
    {

    }
    public void SetId(int id,int num = 1)
    {
        this.id = id;
        this.num = num;
        this.info = ObjectsInfo.instance.GetObjectInfoByID(id);

        InventoryItem item = GetComponentInChildren<InventoryItem>();// = getcomgT
        item.SetIconName(info.iconName);
        numLabel.gameObject.SetActive(true);
        numLabel.text = num.ToString();
    }
    public void ClearInfo()
    {
        id = 0;
        num = 0;
        info = null;
        numLabel.gameObject.SetActive(false);
    }
    public int ID
    {
        get { return id; }
    }
    public int Num
    {
        get { return num; }
    }
    public void addNum(int count = 1)
    {
        num += count;
        numLabel.text = num.ToString();
    }
}
