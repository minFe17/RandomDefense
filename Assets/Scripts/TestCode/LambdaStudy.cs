using System;
using System.Threading.Tasks;
using UnityEngine;

public class LambdaStudy : MonoBehaviour
{
    void Start()
    {
        myRoutine mr = new myRoutine();
        mr.startSync();
        
    }

    void stash()
    {
        //myFunc();
        //Debug.Log(AddFunc(5, 3));

        //var i = 10;
        //i = minusFunc(10, 5);

        //int minusFunc(int a, int b) => a - b;   // ���� �Լ�
        //Func<int, int, int> retFunc = minusFunc;
        //retFunc = (x, y) => x - y;  // ���� �Լ�

        //Func<int[], int> avgFunc = (x) =>
        //{
        //    int sum = 0;
        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        sum += x[i];
        //    }

        //    return sum / x.Length;
        //};
        //int[] arr = { 3, 5, 4, 3, 2 };
        //Debug.Log(avgFunc(arr));
    }

    void myFunc() => Debug.Log("myFunc()�� ȣ��Ǿ����ϴ�");

    int AddFunc(int a, int b) => a + b;
}

public class myRoutine
{
    public void startSync()
    {
        Task.Run(goSync);
        Task.Run(() => Debug.Log("�Լ��� �����մϴ�"));
    }

    async Task goSync()
    {
        await Task.Delay(5000);
        Debug.Log("end delay");
    }
}
