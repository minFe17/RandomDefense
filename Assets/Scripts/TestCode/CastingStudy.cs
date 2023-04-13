using System;
using UnityEngine;

public class CastingStudy : MonoBehaviour
{
    void Start()
    {
        // 암시적 형변환
        int i = 0;
        i = 10;
        short s = 2;
        i = s;
        float f = i;
        // 대부분 값이 잘리거나 반올림되지 않고 맞출수 있을 때 암시적 형변환가능

        Animal animal = new Mammal();   // 상속받은 부모 클래스, 인터페이스로 암시적 변환 항상 가능

        // 명시적 형변환
        s = (short)i;
        i = (int)f;

        Mammal m = (Mammal)animal;
        //Mammal m2 = (Mammal)new CastingStudy();

        // 함수를 통한 형변환
        string str = i.ToString();
        str = "문자열";
        //Reptile rp = (Reptile)animal;

        try
        {
            i = int.Parse(str);
        }
        catch (DivideByZeroException ex)   // 어떤 수를 0으로 나누려고 시도했을 때 발생하는 오류
        {
            Debug.LogError($"발생한 에러는 : {ex}");
        }
        catch (FormatException ex)         // 변환하려는 형식이 맞지 않을때 오류
        {
            Debug.LogError($"발생한 에러는 : {ex}");
        }
        catch (NullReferenceException ex) // 접근하려는 객체가 null일 때
        {
            Debug.LogError($"발생한 에러는 : {ex}");
        }
        catch (InvalidCastException ex)   //형변환 오류
        {
            Debug.LogError($"발생한 에러는 : {ex}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"발생한 에러는 : {ex}");
        }

        //is, as 구문
        Reptile rp = animal as Reptile; //익셉션 없이 안전하게 캐스팅 시도, 안될경우 null을 리턴
        if (rp == null)
            Debug.Log("rp는 null입니다");

        if (animal is Mammal)            // animal객체가 Mammal 타입으로 형변환 가능한지 체크하고 true, false를 리턴한다.
            Debug.Log("animal는 Mammal 타입입니다");

        if(animal is Reptile)
        {
            Debug.Log("animal는 Reptile 타입입니다");
        }
        else
        {
            Debug.Log("animal는 Reptile 타입이 아닙니다");
        }

        Debug.Log("함수 종료시 출력되는 구문입니다.");
    }
}

public class Animal
{

}

public class Mammal : Animal
{

}

public class Reptile : Animal
{

}
