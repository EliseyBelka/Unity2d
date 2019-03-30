using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReloadBar : MonoBehaviour {
    public float maxValue = 100;
    public Color color = Color.magenta;
    private static int width = 4;
    public Slider slider;
    public Transform PosBurReload;


    private static float current;

    void Start()
    {
        slider.fillRect.GetComponent<Image>().color = color;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        current = 0; //при старте значение зарядки 0.
        UpdateUI();
    }

    public static float currentValue
    {
        get { return current; }
    }

    void Update()
    {
        if (current < 0) current = 0;
        if (current > maxValue) current = maxValue;
        slider.value = current;
        //задаем позицию слайдеру для движения за персонажем
        slider.GetComponent<RectTransform>().position = new Vector3(PosBurReload.transform.position.x, PosBurReload.transform.position.y + 1F, PosBurReload.transform.position.z);
    }

    void UpdateUI()
    {
        RectTransform rect = slider.GetComponent<RectTransform>();
        int rectDeltaX = Screen.width / width; //размер по оси х слайдера привязан к размеру экрана усьройства
        rect.sizeDelta = new Vector2(rectDeltaX/3, rect.sizeDelta.y); //размеры слайдера
    }

    public static void AdjustCurrentValue(float adjust)
    {
        current = adjust;
    }
}