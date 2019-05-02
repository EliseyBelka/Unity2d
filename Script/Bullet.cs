using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {
    //угол для задания вращения снаряда
    float angle;
    public Rigidbody2D AID;
    void Start()
    {
        // уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
        Destroy(gameObject, 5);
    }
    private void Update()
    {
        //изменение угла вращения с наращивнаием скорости
        angle += 0.25f;
        //применением вращения к объекту
        transform.Rotate(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Hero") // чтобы пуля не уничтожалась об HERo
        {
            //уничтожаем пулю
            Destroy(gameObject);
        }
        if (collision.collider.tag == "CHBlade") // при попадание в ChineBlade
        {
            //при попадание пули в пилу увеличивать силу тяжести
            collision.collider.GetComponent<Rigidbody2D>().gravityScale += 1.5f;
            //уничтожаем пулю
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Enemy") // чтобы пуля реагировала на Врага
        {
            //битва  с ассасином
            HealthBarEnemy.AdjustCurrentValue(-50);
            //уничтожаем пулю
            Destroy(gameObject);
        }
        if (collision.collider.tag == "FlyEnemy") // чтобы пуля реагировала на летающего врага
        {
            //обращаемся к объекту с которым столкнулись
            Destroy(collision.gameObject);
            //после убийства появляется аптечка АИД
            Instantiate(AID, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            //уничтожаем пулю
            Destroy(gameObject);
        }
    }
  
}
