using System;
using UnityEngine;

public class CastingStudy : MonoBehaviour
{
    void Start()
    {
        // �Ͻ��� ����ȯ
        int i = 0;
        i = 10;
        short s = 2;
        i = s;
        float f = i;
        // ��κ� ���� �߸��ų� �ݿø����� �ʰ� ����� ���� �� �Ͻ��� ����ȯ����

        Animal animal = new Mammal();   // ��ӹ��� �θ� Ŭ����, �������̽��� �Ͻ��� ��ȯ �׻� ����

        // ����� ����ȯ
        s = (short)i;
        i = (int)f;

        Mammal m = (Mammal)animal;
        //Mammal m2 = (Mammal)new CastingStudy();

        // �Լ��� ���� ����ȯ
        string str = i.ToString();
        str = "���ڿ�";
        //Reptile rp = (Reptile)animal;

        try
        {
            i = int.Parse(str);
        }
        catch (DivideByZeroException ex)   // � ���� 0���� �������� �õ����� �� �߻��ϴ� ����
        {
            Debug.LogError($"�߻��� ������ : {ex}");
        }
        catch (FormatException ex)         // ��ȯ�Ϸ��� ������ ���� ������ ����
        {
            Debug.LogError($"�߻��� ������ : {ex}");
        }
        catch (NullReferenceException ex) // �����Ϸ��� ��ü�� null�� ��
        {
            Debug.LogError($"�߻��� ������ : {ex}");
        }
        catch (InvalidCastException ex)   //����ȯ ����
        {
            Debug.LogError($"�߻��� ������ : {ex}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"�߻��� ������ : {ex}");
        }

        //is, as ����
        Reptile rp = animal as Reptile; //�ͼ��� ���� �����ϰ� ĳ���� �õ�, �ȵɰ�� null�� ����
        if (rp == null)
            Debug.Log("rp�� null�Դϴ�");

        if (animal is Mammal)            // animal��ü�� Mammal Ÿ������ ����ȯ �������� üũ�ϰ� true, false�� �����Ѵ�.
            Debug.Log("animal�� Mammal Ÿ���Դϴ�");

        if(animal is Reptile)
        {
            Debug.Log("animal�� Reptile Ÿ���Դϴ�");
        }
        else
        {
            Debug.Log("animal�� Reptile Ÿ���� �ƴմϴ�");
        }

        Debug.Log("�Լ� ����� ��µǴ� �����Դϴ�.");
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
