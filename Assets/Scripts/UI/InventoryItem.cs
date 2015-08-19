using UnityEngine;
using System.Collections;

/*
 * Description: InventoryItem
 * Author:      JiangShu
 * Create Time: 2015/8/19 10:33:46
 */
public class InventoryItem : UIDragDropItem
{
    public int ID
    {
        get { return GetComponentInParent<InventoryItemGrid>().ID; }
    }
    private UISprite sprite;
    void Awake()
    {
        sprite = GetComponent<UISprite>();
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        if (surface != null)
        {
            //空格子
            if(surface.tag == Tags.inventoryItemGrid)
            {
                //拖到当前格子
                if(surface == transform.parent.gameObject)
                {
                    ResetPosition();
                }
                else
                {
                    InventoryItemGrid oldParent = GetComponentInParent<InventoryItemGrid>();
                    transform.parent = surface.transform;
                    transform.localPosition = Vector3.zero;

                    InventoryItemGrid newParent = surface.GetComponent<InventoryItemGrid>();
                    newParent.SetId(oldParent.ID,oldParent.Num);
                    oldParent.ClearInfo();
                }
            }
            //有物品的格子
            else if(surface.tag == Tags.inventoryItem)
            {
                ResetPosition();

                InventoryItemGrid grid1 = GetComponentInParent<InventoryItemGrid>();
                InventoryItemGrid grid2 = surface.GetComponentInParent<InventoryItemGrid>();
                int id = grid1.ID;
                int num = grid1.Num;
                grid1.SetId(grid2.ID, grid2.Num);
                grid2.SetId(id, num);
            }
            else
            {
                ResetPosition();
            }
        }
        else
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
    }

    public void SetId(int id)
    {
        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoByID(id);
        sprite.spriteName = info.iconName;
    }
    public void SetIconName(string iconName)
    {
        sprite.spriteName = iconName;
    }
    public void OnHoverOver()
    {
        InventoryDes.instance.Show(ID);
    }
    public void OnHoverOut()
    {
        InventoryDes.instance.Hide();
    }


}
