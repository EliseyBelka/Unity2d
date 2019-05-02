using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyBullet : MonoBehaviour {
    //угол для задания вращения снаряда
    float angle;
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
        transform.Rotate(0,0,angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Enemy") // чтобы пуля не уничтожалась об врага
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Hero") // чтобы пуля реагировала на Героя
        {
            //урон
            HealthBar.AdjustCurrentValue(-5);
            Destroy(gameObject);
        }
    }
}