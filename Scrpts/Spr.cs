using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spr : MonoBehaviour
{
    #region БЛОК~
    [SerializeField] private Transform BornPointSpear;   //отправная точка копья при метание
    [SerializeField] static int speed = 8;               //скорость копья
    [SerializeField] private float LifeTime = 5;         //время сушествования копья
    [SerializeField] private int damage = 1;             //наносимый урон
    public bool Check = false;                           //проверка выполнене ли разворот стрелы в такт развороту персонажа
    #endregion
    void Start ()
    {
        Destroy(gameObject,LifeTime);
	}
	void Update ()
    {
        #region Перемещения снаряда и его переворот

        //если персонаж смотрит влево
        if (GameObject.FindGameObjectWithTag("Player").
            GetComponent<Transform>().transform.position.x > gameObject.transform.position.x)
        {
            if (Check == false)
            {
                Check = true;
                StartCoroutine(Move());
            }
        }

        //если персонаж смотрит влево
        if (GameObject.FindGameObjectWithTag("Player").
            GetComponent<Transform>().transform.position.x < gameObject.transform.position.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        #endregion
    }
    /// <summary>
    /// Описание столкновения с противником
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.Damage(damage);
            Destroy(gameObject);
            //подсчет количество очков - 1 попадание 1 очко
            InterclassVariables.PointForKill++;
        }
    }
    /// <summary>
    /// Метод отвечающий за разворот копья при метании влево
    /// </summary>
    /// <returns></returns>
    IEnumerator Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        gameObject.transform.Rotate(0, 180, 0);
        yield return new WaitForSeconds(LifeTime);
        Check = false;
    }
}