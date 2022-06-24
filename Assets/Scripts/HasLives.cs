using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasLives : MonoBehaviour
{
    public int amountOfLives;

    void Start()
    {
        if (amountOfLives == 0) amountOfLives = 3;
    }
    private void Update()
    {
        if (amountOfLives < 1) GameOver();
    }

    private void GameOver()
    {
        //do gameover shit
    }
}
