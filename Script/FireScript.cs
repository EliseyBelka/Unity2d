using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
    public float speed = 10; // скорость пули
    public Rigidbody2D bullet; // префаб пули
    public Transform GunPoint; // точка рождения
    private static float fireRate = 100; //задержка перезарядки !!!!Педелать авто пересчет перезарядки связанной со скорострельностью
    public Transform zRotate; // объект для вращения по оси Z
   // private Animator anim;//ссылка на компонент анимаций
    // ограничение вращения
    public float minAngle = -45;
    public float maxAngle = 45;
    private float curTimeout; //текущее время зарядки

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        else
        {
            ReloadBar.AdjustCurrentValue(+curTimeout);//заполнение индикатора перезарядки
            if (curTimeout < 100) //если уровень зарядки меньше 100 (в скрипте ReloadBar)
            {
                curTimeout += 1; //увеличивать уровень зарядки
            }
        }
       if (zRotate) SetRotation(); //!!! РАЗОБРАТЬСЯ С ВРАЩЕНИЕМ ОРУЖИЯ!!!!!!!!!
    }

    void SetRotation()
    {
        Vector3 mousePosMain = Input.mousePosition;                      //получаем координаты курсора
        mousePosMain.z = Camera.main.transform.position.z;               //глубина позиции слоя = к уровню слоя камеры
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);  //Преобразует pos экранного пространства в мировое пространство
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg; //возвращает числовое значение от -π до π --Константа преобразования радиан в градусы
        angle = Mathf.Clamp(angle, minAngle, maxAngle);                  // ограничения внутри диапазона , минимум , максимум
        zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //cоздает вращение на угол angle вокруг оси. -- Сокращения для письма Vector3(0, 0, 1).
    }
    void Fire()
    {
 //       curTimeout += Time.deltaTime; //время между текущим и предыдущим кадром. 
        if (curTimeout >= fireRate)
        {
            ReloadBar.AdjustCurrentValue(-100);//обнуление индикатора перзарядки
            curTimeout = 0;
            Rigidbody2D clone = Instantiate(bullet, GunPoint.position, Quaternion.identity) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(GunPoint.right * -speed);
            clone.transform.right = GunPoint.right;
        }
    }
}