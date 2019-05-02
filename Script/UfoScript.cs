using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour {
    [SerializeField] GameObject target;
    [SerializeField] Camera herocam;
    bool stay=true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hero")
        {
          stay = false;
        }
    }

    private void Update()
    {
        if (!stay)
        {
            gameObject.transform.position += new Vector3(0.05f, 0.5f);
            target.GetComponent<Rigidbody2D>().position = gameObject.transform.position;
            if (herocam.orthographicSize < 50)
            {
                herocam.orthographicSize += 0.2f;
            }
            if (herocam.orthographicSize >= 30)
            {
                target.SetActive(false);
                HealthBar.AdjustCurrentValue(-50);
                ReloadBar.AdjustCurrentValue(-100);
                
            }
        }
    }
}