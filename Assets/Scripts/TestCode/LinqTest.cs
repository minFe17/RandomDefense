using System.Linq;
using UnityEngine;

public class LinqTest : MonoBehaviour
{
    Mountain[] _mountains =
        {
            new Mountain(){ Height = 272.5f, Name = "����", Length = 2300},
            new Mountain(){ Height = 630f, Name = "���ǻ�", Length = 4000},
            new Mountain(){Height = 350f, Name = "�Ͼǻ�", Length = 5200},
            new Mountain(){Height = 1700.5f, Name = "���ǻ�", Length = 3700},
            new Mountain(){Height = 2000.5f, Name = "�Ѷ��", Length = 9600},
            new Mountain(){Height = 2800.5f, Name = "��λ�", Length = 1400},
        };

    void Start()
    {
        //SearchHeight(1000);
        //SearchLinqHeight(1000);
        SearchMountainData();
    }

    void SearchHeight(float height)
    {
        foreach (Mountain mountain in _mountains)
        {
            if (mountain.Height > height)
            {
                Debug.Log($"Name : {mountain.Name}, Height : {mountain.Height}");
            }
        }
    }

    void SearchLinqHeight(float height)
    {
        var result = from mountain in _mountains
                     where mountain.Height >= height
                     orderby mountain.Height ascending
                     select mountain;
        foreach (var mountain in result)
            Debug.Log($"Name : {mountain.Name}, Height : {mountain.Height}");
    }

    void SearchMountainData()
    {
        var result = from mountain in _mountains
                     where mountain.Length > 2500
                     orderby mountain.Height ascending
                     select mountain;

        foreach (var mountain in result)
            Debug.Log($"�̸��� : {mountain.Name}, ���̴� : {mountain.Height}, ���� ���� : {mountain.Length}");
    }
}

public class Mountain
{
    public float Height;
    public string Name;
    public float Length;
}