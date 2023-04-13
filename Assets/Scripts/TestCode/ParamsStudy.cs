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

    void myParamFunction(params int[] a) // params라는 키워드를 통해서 특정타입을 배열로 전달받을 수 있음
    {
        for (int i = 0; i < a.Length; i++)
            Debug.Log(a[i]);
    }

    void valueInt(int a)    // 복사 전달, 값 전달
    {
        a = 10;
        Debug.Log($"value int a : {a}");
    }

    void refInt(ref int a)  // 참조 전달
    {
        a = 10;
        Debug.Log($"ref int a : {a}");
    }

    void inInt(in int a)
    {
        //a = 10; // 입력받은 인자값 수정 불가
    }

    void outInt(out int a)  // ref와 비슷하게 참조 전달하는데 반드시 할당해줘야함
    {
        a = 1000; // 리턴과 동일
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