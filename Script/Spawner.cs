using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;         //противник
    public Transform spawnPoint;     //точка спавн противника

    public static Spawner Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// Спавн грифа после падения дерева
    /// </summary>
    public void SpawnGrif()
    {
        //спавн противника грифа
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);
        //смещение позиции нововго грифа
        spawnPoint.position += new Vector3(10, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PHor")
        {
            Destroy(collision.collider);
            Instantiate(enemy, collision.collider.transform.position, collision.collider.transform.rotation); }
        
    }

}
