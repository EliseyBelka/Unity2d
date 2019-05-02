using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWind : MonoBehaviour {

    //используется для заполнения словаря игровымии объектами
    //необходимо в связи с проблемой в поиске скрытых объектов FindGameObjectWithTag - не видит скрытые.
    //в связи с этим не применимо к скрытым  SetActive(true)
    private void Awake()
    {
        //Поиск всех объектов с которыми будем играть в "покажи и скрой" при формирвоаниии игровых сцен:::
        // камера с игрой
        objHandler.AddReference("MainCamera", GameObject.FindGameObjectWithTag("MainCamera"));
        // игровые компоненты
        objHandler.AddReference("GAME", GameObject.FindGameObjectWithTag("GAME"));
        // камера меню
        objHandler.AddReference("MenuCamera", GameObject.FindGameObjectWithTag("MenuCamera"));
        // объекты главного меню
        objHandler.AddReference("MainMenu", GameObject.FindGameObjectWithTag("MainMenu"));
       
        // скрыть игровые объекты на время отображения меню
        GameObject.FindGameObjectWithTag("GAME").SetActive(false);
        // скрыть камеру игры на время отображения меню
        GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
    }
    // Закрыть окнов игры при нажатие на выход в меню
    public void close () {
        Application.Quit();
    }
    /// <summary>
    ///  Постанвка игры на паузу
    /// </summary>
    public void pause()
    {
        //скрыть Камеру игры и игровые объекты
        objHandler.objRefs["GAME"].SetActive(false);
        objHandler.objRefs["MainCamera"].SetActive(false);
        //показать Камеру меню и объекты меню
        objHandler.objRefs["MenuCamera"].SetActive(!false);
        objHandler.objRefs["MainMenu"].SetActive(!false);
    }
}
