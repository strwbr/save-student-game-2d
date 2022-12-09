using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speedX = 1f; // ск-ть по оси ’
    [SerializeField] private float jumpForce = 300f; // сила прыжка

    private Rigidbody2D _rb;
    //private Finish _finish; // финиш
    private float _horizontal = 0f; // нажата€ клавиша (в какую сторону должен двигатьс€ игрок)

    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private bool _isFinish = false; // это финиш?

    public float speedMultiplier = 50f; // множитель скорости    
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

        //// нажатие на F - завершение уровн€
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    // если игрок находитьс€ на финише (в его коллайдере),
        //    if (_isFinish /*&& dolgiCount == 0*/)
        //    {
        //        // то деактивируем объект finish, вызвав метод из скрипта Finish
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
            _rb.AddForce(new Vector2(0f, jumpForce)); // придание силы дл€ прыжка
            _isGround = false;
            _isJump = false; // игрок в воздухе Ќ≈ прыгает
        }

        // если игрок идет вправо, но смотрит влево, то поворачиваем его спрайт (измен€ем scale)
        if (_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        } // если идет влево, но смотрит вправо, то тоже поворачиваем
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

    /*поворот игрока в зависимости от направлени€ движени€*/
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    /*при соприкосновении с коллайдером долга сверху долг "умирает"
     провер€етс€, в чей коллайдер попал игрок*/
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //if (other.CompareTag("Finish"))
        //{
        //    Debug.Log("It's FINISH!");
        //    _isFinish = true;
        //    _finish.ActivateFinish();
        //}
    }

    /* провер€етс€, из чьего коллайдер вышел игрок */
    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.CompareTag("Finish"))
        //{
        //    Debug.Log("It's NOT FINISH!");
        //    _isFinish = false;
        //}
    }
}
