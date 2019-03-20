using System.Collections;
using UnityEngine.UI;                       // библиотека пользовательского интерфейса
using UnityEngine;
public class BckGrndScrpts : MonoBehaviour
{
    public float speed = 0;                 // скорость слоев
    float pos = 0;                          //переменная позиции картинки
    private RawImage image;                 //создаем объект нашей картинки
    void Start ()
    {
        image = GetComponent<RawImage>();   //получаем ссылку на картинку
    }
	void Update ()                          // как, с какой скоростью и куда мы будем двигать нашу картинку
    {
        pos += speed;
        if (pos > 1.0F)
            pos -= 1.0F;
        image.uvRect = new Rect(pos, 0, 1, 1);
    }
}