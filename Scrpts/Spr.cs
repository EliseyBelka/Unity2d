using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spr : MonoBehaviour
{
    [SerializeField] static int speed=8;
    [SerializeField] private float LifeTime=5;
    [SerializeField] private int damage = 1;
	void Start ()
    {
        Destroy(gameObject,LifeTime);
	}
	void Update ()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.Damage(damage);
            Destroy(gameObject);
        }
    }
}
