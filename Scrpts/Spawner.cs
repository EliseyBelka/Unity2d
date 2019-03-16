using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject _Fire;
    [SerializeField] GameObject _enemy;
    [SerializeField] Transform _spawnPoints;
    [SerializeField] GameObject StoneGateL;//поле для створки ворот левая
    [SerializeField] GameObject StoneGateR;//поле для створки ворот правая
    float lvlPush = 0.16F;//глубина нажатия кнопки
    float lvlOpenDoor = 0.55F;//глубина открытия двери


    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            StoneGateL.transform.Translate(lvlOpenDoor, 0, 0);
            StoneGateR.transform.Translate(lvlOpenDoor, 0, 0);
            gameObject.transform.Translate(0, -lvlPush, 0);
            Instantiate(_enemy, _spawnPoints.position, _spawnPoints.rotation);
            //Instantiate(_Fire, _spawnPoints.position, _spawnPoints.rotation);
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.Translate(0, lvlPush, 0);
            StoneGateL.transform.Translate(-lvlOpenDoor, 0, 0);
            StoneGateR.transform.Translate(-lvlOpenDoor, 0, 0);
        }
    }
}
