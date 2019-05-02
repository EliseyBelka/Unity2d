using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParallaxBG : MonoBehaviour {

    public float speed = 0;                 //скорость слоя
    float pos = 0;                          //позиция картинки
    private RawImage image;                 //создание объекта - картинки

	void Start () {
        image = GetComponent<RawImage>();   //ссылка на картинку
	}

    void Update () {
        pos += speed;
        if (pos > 1.0F)
            pos -= 1.0F;
        image.uvRect = new Rect(pos, 0, 1, 1);
    }
}
