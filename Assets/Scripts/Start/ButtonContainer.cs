using UnityEngine;
using System.Collections;

/*
 * Description: ButtonContainer
 * Author:      JiangShu
 * Create Time: 2015/8/13 16:07:03
 */
public class ButtonContainer : MonoBehaviour
{
    //游戏数据的保存用PlayerPrefs

    //场景分类
        //1.开始场景
        //2.角色选择界面
        //3.游戏场景

    public void OnNewGame()
    {
        //加载场景2
        PlayerPrefs.SetInt("DataFromSave", 0);
    }
    public void OnLoadGame()
    {
        //加载保存的进度
        //加载场景3
        PlayerPrefs.SetInt("DataFromSave", 1);//表示是否通过加载
    }
}
