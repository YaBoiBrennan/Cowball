using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Here");
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.collectedBottle();
            Destroy(gameObject);

        }
    }
}
