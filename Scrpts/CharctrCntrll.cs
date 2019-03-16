using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharctrCntrll : MonoBehaviour
{
    [SerializeField] private GameObject spear;
    [SerializeField] private Transform BornPointSpear;
    [SerializeField] public float maxSpeed = 7f;         //макс. скорости персонажа
    static bool isFacingRight = true;                   //направления персонажа вправо/влево
    private Animator anim;                               //ссылка на компонент анимаций
    Rigidbody2D MyBody;
    #region Начальная инициализация
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    #endregion
    #region Стрельба

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //герой смотрит влево
            if (gameObject.transform.position.x>BornPointSpear.position.x)
            {

                BornPointSpear.transform.Rotate(0, 180, 0);
                Instantiate(spear, BornPointSpear.position, BornPointSpear.rotation);
                BornPointSpear.transform.Rotate(0, -180, 0);
            }
            //герой смотрит вправо
            if (gameObject.transform.position.x < BornPointSpear.position.x)
            {

                Instantiate(spear, BornPointSpear.position, BornPointSpear.rotation);
            }
        }
    }
    #endregion
    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        System.Console.WriteLine("work");
        anim.SetFloat("Speed", Mathf.Abs(move));
        MyBody = GetComponent<Rigidbody2D>();
        MyBody.velocity = new Vector2(move * maxSpeed, MyBody.velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }
    #region Метод для смены направления движения персонажа и его зеркального отражения
    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
    #endregion
}