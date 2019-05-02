using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHeroSky : MonoBehaviour {
    GameObject[] ChainBlade;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            ChainBlade = GameObject.FindGameObjectsWithTag("CHBlade");
            foreach (GameObject CHB in ChainBlade)
            {
                CHB.GetComponent<Rigidbody2D>().gravityScale = -5;
            }
               
        }
    }
}
