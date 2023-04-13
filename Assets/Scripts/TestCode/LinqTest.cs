using System.Linq;
using UnityEngine;

public class LinqTest : MonoBehaviour
{
    Mountain[] _mountains =
        {
            new Mountain(){ Height = 272.5f, Name = "남산", Length = 2300},
            new Mountain(){ Height = 630f, Name = "관악산", Length = 4000},
            new Mountain(){Height = 350f, Name = "북악산", Length = 5200},
            new Mountain(){Height = 1700.5f, Name = "설악산", Length = 3700},
            new Mountain(){Height = 2000.5f, Name = "한라산", Length = 9600},
            new Mountain(){Height = 2800.5f, Name = "백두산", Length = 1400},
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
            Debug.Log($"이름은 : {mountain.Name}, 높이는 : {mountain.Height}, 등산로 길이 : {mountain.Length}");
    }
}

public class Mountain
{
    public float Height;
    public string Name;
    public float Length;
}