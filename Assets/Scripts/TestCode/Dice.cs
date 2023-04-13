using UnityEngine;

public class Dice : MonoBehaviour
{
    void Start()
    {
        //DiceGame(6, 2, 1);
        //DiceGame(2, 6, 1);
        //DiceGame(1, 2, 5);

        FindSpace(12, 5);
        FindSpace(9, -13);
    }

    void DiceGame(int a, int b, int c)
    {
        if (a == b && b == c)       // a, b, c가 같을 때
        {
            int sum = 10000 + (a * 1000);
            Debug.Log(sum);
        }
        else if (a == b || a == c)  // a가 b나 c와 같을 때
        {
            int sum = 1000 + (a * 100);
            Debug.Log(sum);
        }
        else if (b == c)            // b, c가 같을 때
        {
            int sum = 1000 + (b * 100);
            Debug.Log(sum);
        }
        else                        // 3개의 주사위가 모두 다른 때
        {
            if (a < c && b < c)         // c가 클 때
            {
                Debug.Log(c * 100);
            }
            else if (a < b && c < b)    // b가 클 때 
            {
                Debug.Log(b * 100);
            }
            else                        // a가 클 때
            {
                Debug.Log(a * 100);
            }
        }
    }

    void FindSpace(int x, int y)
    {
        if (x == 0 || y == 0)
            Debug.Log("사분면에 속해있지 않습니다");
        else if (x < 0)
        {
            if (y < 0)
                Debug.Log(3);
            else
                Debug.Log(2);
        }
        else
        {
            if (y < 0)
                Debug.Log(4);
            else
                Debug.Log(1);
        }
    }
}
