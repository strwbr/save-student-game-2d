using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speedX = 1f; // ��-�� �� ��� �
    [SerializeField] private float jumpForce = 300f; // ���� ������

    private Rigidbody2D _rb;
    //private Finish _finish; // �����
    private float _horizontal = 0f; // ������� ������� (� ����� ������� ������ ��������� �����)

    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private bool _isFinish = false; // ��� �����?

    public float speedMultiplier = 50f; // ��������� ��������    
    public MoveBackground background;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _isGround)
        {
            _isJump = true;
        }

        //// ������� �� F - ���������� ������
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    // ���� ����� ���������� �� ������ (� ��� ����������),
        //    if (_isFinish /*&& dolgiCount == 0*/)
        //    {
        //        // �� ������������ ������ finish, ������ ����� �� ������� Finish
        //        _finish.FinishLevel();
        //    }
        //}
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * speedX * Time.fixedDeltaTime * speedMultiplier, _rb.velocity.y);
        //background.Move();
        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, jumpForce)); // �������� ���� ��� ������
            _isGround = false;
            _isJump = false; // ����� � ������� �� �������
        }

        // ���� ����� ���� ������, �� ������� �����, �� ������������ ��� ������ (�������� scale)
        if (_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        } // ���� ���� �����, �� ������� ������, �� ���� ������������
        else if (_horizontal < 0f && _isFacingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }

    /*������� ������ � ����������� �� ����������� ��������*/
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    /*��� ��������������� � ����������� ����� ������ ���� "�������"
     �����������, � ��� ��������� ����� �����*/
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //if (other.CompareTag("Finish"))
        //{
        //    Debug.Log("It's FINISH!");
        //    _isFinish = true;
        //    _finish.ActivateFinish();
        //}
    }

    /* �����������, �� ����� ��������� ����� ����� */
    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.CompareTag("Finish"))
        //{
        //    Debug.Log("It's NOT FINISH!");
        //    _isFinish = false;
        //}
    }
}
