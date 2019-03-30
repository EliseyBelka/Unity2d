using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!!!! доделать наклон дерева при каждом попадание !!!!

public class BridgeLog : MonoBehaviour {
    int LifeTree = 3; //жизни дерева
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Bullet")
        {
            //валим деревья с 3 выстрелов
            if (LifeTree <= 0)
            {
                // отключение заморозки дерева.
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            else
            { --LifeTree; }
           
        }
    }
}
