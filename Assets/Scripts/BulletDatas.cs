using System;
using UnityEngine;

public class BulletDatas : MonoBehaviour
{
    private BulletData[] arr = null;
    public BulletData this[EBulletType eType]   // �ε���(��� �÷���)
    {
        get
        {
            if (arr == null)
            {
                ReadData();
            }
            foreach (var data in arr)
            {
                if (data.eType == eType)
                    return data;
            }
            return new BulletData();
        }
    }

    void ReadData()
    {
        var data = csvReader.ReadFileData("BulletData");
        if (data.Length < 2)    // ���� �Ѱ��� ���� ���(����� �ִ� ���)
            return;
        arr = new BulletData[data.Length - 1];
        for (int i = 1; i < data.Length; i++)
        {
            var lineItem = data[i].Split(',');
            BulletData db;
            db.ID = int.Parse(lineItem[0]);
            db.Speed = float.Parse(lineItem[1]);
            db.Damage = int.Parse(lineItem[2]);
            db.eType = (EBulletType)Enum.Parse(typeof(EBulletType), lineItem[3]);
            arr[i - 1] = db;
        }
    }
}

public struct BulletData
{
    public int ID;
    public float Speed;
    public int Damage;
    public EBulletType eType;
}
