using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour {

    [SerializeField] private int health = 3;        //очки здоровья противника
    /// <summary>
    /// Нанесение урона противнику
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
}