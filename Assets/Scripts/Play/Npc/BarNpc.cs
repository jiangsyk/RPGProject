using UnityEngine;
using System.Collections;

/*
 * Description: BarNpc
 * Author:      JiangShu
 * Create Time: 2015/8/18 14:41:32
 */
public class BarNpc : Npc
{
    public bool isInTask = false;//是否接受任务
    public int killCount = 0;//杀死的数量

    public TweenPosition questTween;
    public UILabel desLabel;
    public GameObject acceptBtn;
    public GameObject okBtn;
    public GameObject cancelBtn;

    private PlayerStatus playerStatus;

    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }

    protected override void OnNpcClick()
    {
        base.OnNpcClick();
        ShowQuest();
    }
    
    void ShowQuest()
    {
        if(isInTask)
        {
            ShowTaskProgress();
        }
        else
        {
            ShowTaskDes();
        }
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }
    void HideQuest()
    {
        questTween.PlayReverse();
    }

    void ShowTaskDes()
    {
        desLabel.text = "任务：\n杀死了10只狼\n\n奖励：\n1000金币";
        okBtn.SetActive(false);
        acceptBtn.SetActive(true);
        cancelBtn.SetActive(true);
    }
    void ShowTaskProgress()
    {
        desLabel.text = "任务：\n你已经杀死了" + killCount + "/10只狼\n\n奖励：\n1000金币";
        okBtn.SetActive(true);
        acceptBtn.SetActive(false);
        cancelBtn.SetActive(false);
    }
    //处理任务面板上的close
    public void OnCloseBtnClick()
    {
        HideQuest();
    }
    public void OnAcceptBtnClick()
    {
        isInTask = true;

        ShowTaskProgress();
    }
    public void OnOkBtnClick()
    {
        if(killCount >= 10)
        {
            //完成
            playerStatus.GetCoin(1000);

            killCount = 0;
            isInTask = false;
            ShowTaskDes();
        }
        else
        {
            //未完成
            HideQuest();
        }
    }
    public void OnCancelBtnClick()
    {
        HideQuest();
    }
}
