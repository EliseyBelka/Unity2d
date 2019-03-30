using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour {
    void Start()
    {
        // уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Hero") // чтобы пуля не реагировала на HERo
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Enemy") // чтобы пуля не реагировала на HERo
        {
            HealthBarEnemy.AdjustCurrentValue(-50);
            Destroy(gameObject);
        }
    }
  
}
