using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHero : MonoBehaviour {
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            collision.gameObject.transform.position = new Vector3(-3.49F, -3.57F, 0.0281F);
            HealthBar.AdjustCurrentValue(-25);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.transform.position = new Vector3(36F, -3.57F, 0.0F);
            HealthBarEnemy.AdjustCurrentValue(+25);
        }
    }
}
