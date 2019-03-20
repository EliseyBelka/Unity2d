using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    #region БЛОК~
    //[SerializeField] GameObject _Fire;        //снаряд статуи
    [SerializeField] GameObject _enemy;         //противник
    [SerializeField] Transform _spawnPoints;    //точка спавн противника
    [SerializeField] GameObject StoneGateL;     //поле для створки ворот левая
    [SerializeField] GameObject StoneGateR;     //поле для створки ворот правая
    float lvlPush = 0.16F;                      //глубина смешений нажатой кнопки
    float lvlOpenDoor = 0.55F;                  //глубина смешения открытой двери
    #endregion
    /// <summary>
    /// Герой наступил на кнопку
    /// </summary>
    /// <param name="Collision"></param>
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            //кнопка нажата
            gameObject.transform.Translate(0, -lvlPush, 0);
            //подсчет заспавненых противников
            InterclassVariables.NumberOfEnemy++;
            //если не вышло 5 врагов - жать открывать спавнить
            if (InterclassVariables.NumberOfEnemy < 6)
            {
                //открытие L и R створки двери
                StoneGateL.transform.Translate(lvlOpenDoor, 0, 0);
                StoneGateR.transform.Translate(lvlOpenDoor, 0, 0);
                //спавн противника
                Instantiate(_enemy, _spawnPoints.position, _spawnPoints.rotation);
        
            }
            //Instantiate(_Fire, _spawnPoints.position, _spawnPoints.rotation);
        }

    }
    /// <summary>
    /// Герой ушел с кнопки
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //кнопка отжата
            gameObject.transform.Translate(0, lvlPush, 0);
            if (InterclassVariables.NumberOfEnemy < 6)
            {
                //створка L и R закрылись
                StoneGateL.transform.Translate(-lvlOpenDoor, 0, 0);
                StoneGateR.transform.Translate(-lvlOpenDoor, 0, 0);
            }
        }
    }
}