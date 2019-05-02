using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDamage : MonoBehaviour
{
    //дистанция до атаки
    public float attackDistance = 2f;
    //игрок
    private Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Hero").transform;
    }

    void Update()
    {
        //подошел на расстояние ближней атаки
        Debug.Log(Vector2.Distance(transform.position, target.transform.position));
        if (Vector2.Distance(transform.position, target.transform.position) < attackDistance)
        {
            //отнимание здоровья
            HealthBar.AdjustCurrentValue(-0.10f);

        }
        if (GetComponent<Rigidbody2D>().gravityScale < 0)
        {
            //применением вращения к объекту
            transform.Rotate(0, 0, GetComponent<Rigidbody2D>().gravityScale*7);
        }
    }
}
