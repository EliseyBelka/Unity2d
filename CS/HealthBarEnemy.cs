using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarEnemy : MonoBehaviour {
    public float maxValue = 100;
    public Color color = Color.black;
    private static int width = 3; //переменная для взаимосвязи с экраном
    public Slider slider;
    public Transform PosHealthSlider;
    private static float current; //текущее значение здоровья

    void Start()
    {
        slider.fillRect.GetComponent<Image>().color = color;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        current = maxValue; //при старте максимум здоровья
        UpdateUI(); //создание слайдера
    }

    public static float currentValue //метод на заказ текущего значения здоровья
    {
        get { return current; }
    }

    void Update()
    {
        if (current < 0) current = 0; //ограничитель слева слайдера
        if (current > maxValue) current = maxValue;//ограничитель справа слайдера
        slider.value = current; //присвоить текушее значение слайдеру
        //задаем позицию слайдеру для движения за владельцем
        slider.GetComponent<RectTransform>().position = 
            new Vector3(
                PosHealthSlider.transform.position.x, 
                PosHealthSlider.transform.position.y + 1.2F,
                PosHealthSlider.transform.position.z);
        if (current <= 0)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }

    void UpdateUI()
    {
        RectTransform rect = slider.GetComponent<RectTransform>();
        int rectDeltaX = Screen.width / width; //размер по оси х слайдера привязан к размеру экрана усьройства
        rect.sizeDelta = new Vector2(rectDeltaX / 3, rect.sizeDelta.y); //размеры слайдера
    }
    /// <summary>
    /// Взаимодействие с переменной ЗДОРОВЬЯ у владельца через метод
    /// </summary>
    /// <param name="adjust"> число на которое необходимо изменить здоровье</param>
    public static void AdjustCurrentValue(float adjust)
    {
        current += adjust;
    }
}