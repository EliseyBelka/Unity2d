using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoov : MonoBehaviour {
    //вертикальная сила гравити
    [SerializeField] Vector2 GravityForceV = new Vector2(0, 6);
    //горизонтальная сила гравити
    [SerializeField] Vector2 GravityForceH = new Vector2(2, 0);
    //на платформе
    private void OnCollisionStay2D(Collision2D collision)
    {
        //встали на вертикальную платформу
        if (gameObject.tag == "PVer")
        {
            //границы перемещения
            if (gameObject.transform.position.y > 13)
                //при достижении границы меняем напарвление
                GravityForceV = -GravityForceV;
            //границы перемещения
            if (gameObject.transform.position.y < -5)
                //при достижении границы меняем напарвление
                GravityForceV = -GravityForceV;
            //переместить платформу вверх на расстояние определяемое гравитифорс
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + GravityForceV * Time.deltaTime);
        }

        //встали на горизонтальную платформу
        if (gameObject.tag == "PHor")
        {
            //границы перемещения
            if (gameObject.transform.position.x > 83)
                //при достижении границы меняем напарвление
                GravityForceH = -GravityForceH;
            //границы перемещения
            if (gameObject.transform.position.x < 42)
                //при достижении границы меняем напарвление
                GravityForceH = -GravityForceH;
            //переместить платформу в сторону на расстояние определяемое гравитифорс
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + GravityForceH * Time.deltaTime);
        }
        
    }
    //покинули платформу
    private void OnCollisionExit2D(Collision2D collision)
    {
        //если покинули платформу Вертикальную
        if (gameObject.tag == "PVer")
        {
            //вернуть её в исходную точку
           GetComponent<Rigidbody2D>().MovePosition(new Vector2(gameObject.transform.position.x, -5F));
        }
        //если покинули платформу Горизонтальную
        if (gameObject.tag == "PHor")
        {
            //вернуть её в исходную точку к границе
            GetComponent<Rigidbody2D>().MovePosition(new Vector2(83f, gameObject.transform.position.y));
        }
    }

}
