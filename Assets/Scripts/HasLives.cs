using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HasLives : MonoBehaviour
{
    public int amountOfLives, totalAmountOfLives = 3;
    public static int amountOfLivesS, totalAmountOfLivesS = 3;
    GameObject Life1, Life2, Life3;
    List<GameObject> lives = new List<GameObject>();
    //List<UnityEngine.UI.RawImage> lives = new List<UnityEngine.UI.RawImage>();

    void Start()
    {
        if (amountOfLives == 0) amountOfLives = totalAmountOfLives;
        Life1 = GameObject.FindGameObjectWithTag("Life1");
        Life2 = GameObject.FindGameObjectWithTag("Life2");
        Life3 = GameObject.FindGameObjectWithTag("Life3");
        lives.Add(Life1);
        lives.Add(Life2);
        lives.Add(Life3);
    }
    private void Update()
    {
        amountOfLivesS = amountOfLives;
        if (amountOfLives < 1) GameOver();
        ShowLives();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    private void ShowLives()
    {
        for (int i = 0; i < totalAmountOfLives; i++)
        {
            if (i < amountOfLives) lives[i].SetActive(true);
            else lives[i].SetActive(!true);
        }
    }
}
