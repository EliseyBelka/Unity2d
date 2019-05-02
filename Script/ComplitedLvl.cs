using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComplitedLvl : MonoBehaviour {
    public static int score;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        score = 1;
    }

    // Update is called once per frame
    void Update () {
        text.text = "Leve " + score + " complited";
	}
}
