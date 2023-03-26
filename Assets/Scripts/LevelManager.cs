using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int totalBottles;
    private int bottlesCollected;

    private int totalTargets;
    private int targetsDestroyed;
    public TMP_Text counter;

    private float startTime;
    public TMP_Text timer;

    public GameObject menu;
    public TMP_Text menuTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        totalBottles = GameObject.FindGameObjectsWithTag("Bottle").Length;
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;

        if (totalBottles > 0)
        {
            bottlesCollected = 0;
            counter.text = "" + bottlesCollected + "/" + totalBottles;
        }
        else if(totalTargets > 0)
        {
            targetsDestroyed = 0;
            counter.text = "" + targetsDestroyed + "/" + totalTargets;
        }
        else
        {
            counter.text = "";
        }

        startTime = Time.time;
    }

    private void Update()
    {
        float currentTime = Time.time - startTime;
        string minutes = ((int)currentTime / 60).ToString();
        string seconds = (currentTime % 60).ToString("f2");
        timer.text = minutes + ":" + seconds;

    }


    public void collectedBottle()
    {
        bottlesCollected++;
        counter.text = "" + bottlesCollected + "/" + totalBottles;
        if (bottlesCollected == totalBottles)
            Win();
    }

    public void targetDestroyed()
    {
        targetsDestroyed++;
        counter.text = "" + targetsDestroyed + "/" + totalTargets;
        if (targetsDestroyed == totalTargets)
            Win();
    }

    public void Win()
    {
        Time.timeScale = 0;
        menuTime.text = "Time: " + timer.text;
        menu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
