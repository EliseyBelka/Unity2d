using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
    public float speed = 10; // скорость пули
    public Rigidbody2D bullet; // префаб пули
    public Transform GunPoint; // точка рождения
    private static float fireRate = 100; //задержка перезарядки !!!!Педелать авто пересчет перезарядки связанной со скорострельностью
    public Transform zRotate; // объект для вращения по оси Z
  
    private float curTimeout; //текущее время зарядки
    
    void Update()
    {
        //Обработка нжатия стрелять
        if (Input.GetMouseButton(0)) Fire();

        //ПЕРЕЗАРЯДКА
        ReloadBar.AdjustCurrentValue(+curTimeout);//заполнение индикатора перезарядки
        if (curTimeout < 100) //если уровень зарядки меньше 100 (в скрипте ReloadBar)
        {
            curTimeout += 2; //увеличивать уровень зарядки
        }
        
        //Врщение пистолета по курсору мыши
        SetRotation(); 
    }
    //обработка поворота оружия за курсором
    void SetRotation()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        zRotate.rotation = Quaternion.FromToRotation(Vector3.up, pos - transform.position);

    }
        void Fire()
    {
        if (curTimeout >= fireRate)
        {
            ReloadBar.AdjustCurrentValue(-100);//обнуление индикатора перзарядки
            curTimeout = 0;
            //записываем значения координат х и у курсора (локальные коордиаты)
            Vector3 pos = Input.mousePosition;
            //добавляем координату z к значениям координат как координату камеры z-коордианата z объекта
            pos.z = transform.position.z - Camera.main.transform.position.z;
            //переход в мировые координаты
            pos = Camera.main.ScreenToWorldPoint(pos);
            //опеределяем границы поворота
            Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            //создание буллет в точке рождения с квартенионом определенном выше
            Rigidbody2D go = Instantiate(bullet, GameObject.FindGameObjectWithTag("GunPoint").transform.position, q) as Rigidbody2D;
            // предание имульса силы к созданному объекту
            go.GetComponent<Rigidbody2D>().AddForce(go.transform.up * speed);
        }
    }
}