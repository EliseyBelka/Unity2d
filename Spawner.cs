using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] Transform _spawnPoints;
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.tag=="Respawn")
        {
            System.Console.WriteLine("works");
            Instantiate(_enemy, _spawnPoints.position, _spawnPoints.rotation);
        }
    }

}
