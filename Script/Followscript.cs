using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followscript : MonoBehaviour {
    //префаб пули
    public Rigidbody2D bullet; 
    //дистанция от которой он начинает видеть игрока
    public float seeDistance = 25f;
    //дистанция до атаки
    public float attackDistance = 3f;
    //скорость енеми
    public float speed = 2;
    //скорость вылета пули
    public float force = 200;
    //текущее время зарядки
    private float curTimeout=100; 
    //игрок
    private Transform target;
    void Start () {
        target = GameObject.FindWithTag("Hero").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
           transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //подошел на расстояние ближней атаки
            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {
                //отталкивает при получении урона
                GameObject.FindWithTag("Hero").GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5));
                //отнимание здоровья
                HealthBar.AdjustCurrentValue(-0.25f);
            }
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
            {
                Fire();          
            }
           
            //ПЕРЕЗАРЯДКА
            if (curTimeout < 100) //если уровень зарядки меньше 100 (в скрипте ReloadBar)
            {
                curTimeout += 1; //увеличивать уровень зарядки
            }
        }
    }
    //дальняя атака
    void Fire()
    {
        if (curTimeout >= 100)
        {
            curTimeout = 0;
            //создание буллета
            Rigidbody2D go = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
            // предание имульса силы к созданному объекту, через вектор расстояния между источником и целью(нормализовано)
            go.GetComponent<Rigidbody2D>().AddForce((target.position - transform.position).normalized * force);

        } 
        
    }
}
