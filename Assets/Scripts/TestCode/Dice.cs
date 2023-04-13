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
        if (a == b && b == c)       // a, b, c�� ���� ��
        {
            int sum = 10000 + (a * 1000);
            Debug.Log(sum);
        }
        else if (a == b || a == c)  // a�� b�� c�� ���� ��
        {
            int sum = 1000 + (a * 100);
            Debug.Log(sum);
        }
        else if (b == c)            // b, c�� ���� ��
        {
            int sum = 1000 + (b * 100);
            Debug.Log(sum);
        }
        else                        // 3���� �ֻ����� ��� �ٸ� ��
        {
            if (a < c && b < c)         // c�� Ŭ ��
            {
                Debug.Log(c * 100);
            }
            else if (a < b && c < b)    // b�� Ŭ �� 
            {
                Debug.Log(b * 100);
            }
            else                        // a�� Ŭ ��
            {
                Debug.Log(a * 100);
            }
        }
    }

    void FindSpace(int x, int y)
    {
        if (x == 0 || y == 0)
            Debug.Log("��и鿡 �������� �ʽ��ϴ�");
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
