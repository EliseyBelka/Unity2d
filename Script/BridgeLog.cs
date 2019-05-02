using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//!!!! доделать наклон дерева при каждом попадание !!!!

public class BridgeLog : MonoBehaviour {
    int LifeTree = 1; //жизни дерева
    int GrifNum; //количество грифов
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ///Взаимодействие дерева с пулей
        if (collision.collider.tag == "Bullet")
        {
            //валим деревья с 2 выстрелов
            if (LifeTree <= 0)
            {
                // отключение заморозки дерева - разрешение падать
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                //спавн грифа после сваливания дерева ез 2.5ск
                InvokeRepeating("Spawn", 3f, 2.5f);
            }
            else
            { --LifeTree; }
        }
    }
    //метод при вызове задержки
    private void Spawn()
    {
        //если грифов 5 
        if (GrifNum>=4)
        {
            //отменить инвок по спавну грифов
            CancelInvoke("Spawn");
        }
        //спавн грифа
        Spawner.Instance.SpawnGrif();
        //увеличить счетчик спавна
        GrifNum++;
    }
 }
