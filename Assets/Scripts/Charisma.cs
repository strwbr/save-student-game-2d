using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charisma : MonoBehaviour
{
    [SerializeField] private int enemyHelthDeceleration = 10;


    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //// ��� � ��������� ������!!! �� ��������������
        //EnemyHealth enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();

        //if(other.TryGetComponent(out PlayerController playerController))
        //{
        //    enemyHealth.ReduceHealth(enemyHelthDeceleration);
        //    Debug.Log($"HP ����� ����������� �� {enemyHelthDeceleration}");
        //    Destroy(gameObject);

        //}
    }
}
