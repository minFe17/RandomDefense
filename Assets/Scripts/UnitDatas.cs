using System;
using UnityEngine;

public class UnitDatas : MonoBehaviour
{
    private UnitData[] arr = null;
    public UnitData this[EUnitType eType, EUnitSize eSize]
    {
        get
        {
            if (arr == null)
            {
                ReadData();
            }
            foreach (var data in arr)
            {
                if (data.UnitType == eType && data.UnitSize == eSize)
                    return data;
            }
            return new UnitData();
        }
    }

    void ReadData()
    {
        var data = csvReader.ReadFileData("UnitData");
        if (data.Length < 2)
            return;
        arr = new UnitData[data.Length - 1];
        for (int i = 1; i < data.Length; i++)
        {
            var lineItem = data[i].Split(',');
            UnitData ud;
            ud.ID = int.Parse(lineItem[0]);
            ud.Speed = float.Parse(lineItem[1]);
            ud.UnitType = (EUnitType)Enum.Parse(typeof(EUnitType), lineItem[2]);
            ud.BulletType = (EBulletType)Enum.Parse(typeof(EBulletType), lineItem[3]);
            ud.UnitSize = (EUnitSize)Enum.Parse(typeof(EBulletType), lineItem[4]);
            arr[i - 1] = ud;
        }
    }
}

public struct UnitData
{
    public int ID;
    public float Speed;
    public EUnitType UnitType;
    public EBulletType BulletType;
    public EUnitSize UnitSize;
}
