using UnityEngine;

public class ParamsStudy : MonoBehaviour
{
    void Start()
    {
        //myFunction(7);
        //Debug.Log(myIntFunction());
        //myParamFunction(1, 2, 3, 1, 3, 5, 6, 1);

        int a = 5;
        valueInt(a);
        refInt(ref a);
        Debug.Log($"Start int a : {a}");

        inInt(a);
        outInt(out a);
        Debug.Log($"Start out int a : {a}");
    }

    void myFunction(int a)
    {
        Debug.Log(a);
    }

    int myIntFunction()
    {
        return 5;
    }

    void myParamFunction(params int[] a) // params��� Ű���带 ���ؼ� Ư��Ÿ���� �迭�� ���޹��� �� ����
    {
        for (int i = 0; i < a.Length; i++)
            Debug.Log(a[i]);
    }

    void valueInt(int a)    // ���� ����, �� ����
    {
        a = 10;
        Debug.Log($"value int a : {a}");
    }

    void refInt(ref int a)  // ���� ����
    {
        a = 10;
        Debug.Log($"ref int a : {a}");
    }

    void inInt(in int a)
    {
        //a = 10; // �Է¹��� ���ڰ� ���� �Ұ�
    }

    void outInt(out int a)  // ref�� ����ϰ� ���� �����ϴµ� �ݵ�� �Ҵ��������
    {
        a = 1000; // ���ϰ� ����
    }
}

public class paramParent
{
    public virtual void pFunc(params object[] objects)
    {

    }
}

public class paramChild : paramParent
{
    public override void pFunc(params object[] objects)
    {
        Debug.Log($"HP : {objects[0]}");
        Debug.Log($"Attack : {objects[1]}");
    }
}

public class paramChild2 : paramParent
{
    public override void pFunc(params object[] objects)
    {
        Debug.Log($"Def : {objects[0]}");
        Debug.Log($"AttackRate : {objects[1]}");
    }
}