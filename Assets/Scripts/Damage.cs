using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TakeDamage(int amountOfDamage)
    {
        player.GetComponent<HasLives>().amountOfLives = player.GetComponent<HasLives>().amountOfLives - amountOfDamage;
    }
}
