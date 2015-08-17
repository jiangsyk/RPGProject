using UnityEngine;
using System.Collections;

/*
 * Description: CharacterCreation
 * Author:      JiangShu
 * Create Time: 2015/8/17 15:08:49
 */
public class CharacterCreation : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectIndex = 0;
    private int characterLength;

    public UIInput input;

    void Start()
    {
        characterLength = characterPrefabs.Length;
        characterGameObjects = new GameObject[characterLength];
        for(int i = 0;i<characterLength;i++)
        {
            GameObject go = GameObject.Instantiate(characterPrefabs[i],transform.position,transform.rotation) as GameObject;
            go.transform.parent = transform;
            characterGameObjects[i] = go;
        }
        UpdateCharacterShow();
    }
    void Update()
    {
    }
    void UpdateCharacterShow()
    {
        for(int i = 0;i<characterLength;i++)
        {
            characterGameObjects[i].SetActive(i == selectIndex);
        }
    }
    public void OnClickNextBtn()
    {
        selectIndex++;
        /*
        if (selectIndex == characterLength)
            selectIndex = 0;
        */
        selectIndex %= characterLength;
        UpdateCharacterShow();
    }
    public void OnClickPrevBtn()
    {
        selectIndex--;
        if (selectIndex < 0)
            selectIndex = characterLength - 1;
        UpdateCharacterShow();
    }
    public void OnClickSureBtn()
    {
        string name = input.value;
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectIndex);
        PlayerPrefs.SetString("SelectCharacterName", name);
        //加载下一个场景

    }
}
