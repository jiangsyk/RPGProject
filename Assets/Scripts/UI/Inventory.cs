using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Description: Inventory
 * Author:      JiangShu
 * Create Time: 2015/8/19 10:23:01
 */
public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private bool isShow = false;
    private TweenPosition tweenPosition;
    private int coinCount;

    public List<InventoryItemGrid> itemList = new List<InventoryItemGrid>();
    public UILabel coinLabel;
    public GameObject inventoryItemPrefab;

    void Awake()
    {
        instance = this;
        tweenPosition = GetComponent<TweenPosition>();
        tweenPosition.AddOnFinished(OnTweenFinished);
    }
    void Start()
    {

    }
    void Update()
    {
        
    }
    //添加
    public void GetId(int id)
    {
        InventoryItemGrid nullGrid = null;
        //查找是否已存在
        foreach(InventoryItemGrid grid in itemList)
        {
            if(grid.ID == id)
            {
                grid.addNum();
                return;
            }
            else if(grid.ID == 0 && nullGrid == null)
            {
                nullGrid = grid;
            }
        }
        
        //不存在
        if(nullGrid != null)
        {
            GameObject go = NGUITools.AddChild(nullGrid.gameObject, inventoryItemPrefab);
            go.transform.localPosition = Vector3.zero;
            nullGrid.SetId(id);
        }
    }
    void Show()
    {
        isShow = true;
        gameObject.SetActive(true);
        tweenPosition.PlayForward();
    }
    void Hide()
    {
        isShow = false;
        tweenPosition.PlayReverse();
    }
    void OnTweenFinished()
    {
        /*
        //当active = false 的时候 add不进去了 这就是 显示 和 数据 耦合的问题
        if(isShow == false)
            tweenPosition.gameObject.SetActive(false);
        */
        print(tweenPosition.value);
    }

    public void TransformShowState()//转变显示状态
    {
        if (!isShow)
            Show();
        else
            Hide();
    }
}
