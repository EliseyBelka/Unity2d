using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharctrCntrll : MonoBehaviour
{
    #region БЛОК ~
    static bool isFacingRight = true;           //направление взора персонажа
    float lvlOpenDoor = 0.55F;                  //глубина смешения открытой двери
    [SerializeField] GameObject StoneGateL;     //поле для створки ворот левая
    [SerializeField] GameObject StoneGateR;     //поле для створки ворот правая
    [SerializeField] GameObject Key;                     //Ключик
    [SerializeField] GameObject Elevators;               //Подключение лифтов
    [SerializeField] private GameObject spear;           //копье
    [SerializeField] private Transform BornPointSpear;   //отправная точка копья при метание
    [SerializeField] private float jump = 7f;            //сила прыжка
    [SerializeField] public float maxSpeed = 7f;         //макс. скорости персонажа
    public bool Check = false;                           //проверка совершен ли прыжок
    private Animator anim;                               //ссылка на компонент анимаций
    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        # region Действие стрельба польба
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(spear, BornPointSpear.position, BornPointSpear.rotation);
        }
        #endregion
        # region Действие прыг
        if (Input.GetButtonUp("Jump"))
        {
            //если ещё не подпрыгнул
            if (Check == false) 
            {
                //пометка подпрыгнул
                Check = true;
                //вызов прыжкав
                StartCoroutine(Jump());
            }
        }
        #endregion
        #region Перемещения героя + поворот
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
        #endregion
        //если 5(enemy)*3(health) попаданий то открыть уровень 2 лифты
        if (InterclassVariables.PointForKill == 15)
        {
          Elevators.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            InterclassVariables.key = true;
            Destroy(Key);
            StoneGateL.transform.Translate(lvlOpenDoor, 0, 0);
            StoneGateR.transform.Translate(lvlOpenDoor, 0, 0);
        }
    }
    #region Метод прыг
    /// <summary>
    /// Прыжок если персонаж на земле
    /// </summary>
    /// <returns></returns>
    IEnumerator Jump()
    {
        //прыжок через импульс силы
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump, ForceMode2D.Impulse);
        //задержка перд очередным прыжком
        yield return new WaitForSeconds(1.5f);
        //приземлился))) можно разрешить снова прыгать
        Check = false;
    }
    #endregion
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