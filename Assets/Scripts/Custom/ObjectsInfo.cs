using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Description: ObjectsInfo
 * Author:      JiangShu
 * Create Time: 2015/8/18 15:47:22
 */
public class ObjectsInfo : MonoBehaviour
{
    public static ObjectsInfo instance;

    public TextAsset objectsInfoListText;
    private Dictionary<int, ObjectInfo> objects = new Dictionary<int, ObjectInfo>();
    
    void Start()
    {
        instance = this;
        ReadInfos();
    }
    void ReadInfos()
    {
        string text = objectsInfoListText.text;
        string[] strArr = text.Split('\n');
        foreach(string str in strArr)
        {
            string[] propArr = str.Split(',');
            int id = int.Parse(propArr[0]);

            ObjectInfo info = new ObjectInfo();
            info.id = id;
            info.name = propArr[1];
            info.iconName = propArr[2];
            info.type = GetType(propArr[3]);
            if(info.type == ObjectType.Drug)
            {
                info.hp = int.Parse(propArr[4]);
                info.mp = int.Parse(propArr[5]);
            }
            info.sellPrice = int.Parse(propArr[6]);
            info.buyPrice = int.Parse(propArr[7]);

            objects[id] = info;
        }
    }

    ObjectType GetType(string typeStr)
    {
        switch(typeStr)
        {
            case "Drug":
                return ObjectType.Drug;
            case "Equip":
                return ObjectType.Equip;
            case "Mat":
                return ObjectType.Mat;
        }
        return ObjectType.Drug;
    }

    public ObjectInfo GetObjectInfoByID(int id)
    {
        ObjectInfo info;
        objects.TryGetValue(id, out info);
        return info;
    }
}

public class ObjectInfo
{
    public int id = 0;
    public string name = "";
    public string iconName = "";
    public ObjectType type;
    public int hp;
    public int mp;
    public int sellPrice;
    public int buyPrice;
}

public enum ObjectType
{
    Drug,
    Equip,
    Mat
}