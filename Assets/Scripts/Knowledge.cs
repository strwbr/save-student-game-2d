using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knowledge : MonoBehaviour
{
    [SerializeField] private int atkMagnificaton = 10; // �� ������� ����������� ���� ����� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� - ��, � ������� ����� ���� ���� �����
        if (other.TryGetComponent(out PlayerController playerController))
        {
            Debug.Log($"���� ����� ������ ����������� �� {atkMagnificaton}");
            Destroy(gameObject);
        }
    }
}
