using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    GameObject player;

    public bool isImmune, visibilityActive, doColorOnce = true;

    public Color normalColor;
    public Color immuneColor;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        immuneColor.a = (float)0.5;
    }
    
    void CheckColor()
    {
        immuneColor.a = (float)0.5;
    }

    private void Update()
    {
        if (doColorOnce)
        {
            //CheckColor();
            print("checkedColor");
            doColorOnce = false;
        }
        if (isImmune && !visibilityActive) Visibility();
    }

    public void TakeDamage(int amountOfDamage)
    {
        player.GetComponent<HasLives>().amountOfLives = player.GetComponent<HasLives>().amountOfLives - amountOfDamage;
        StartCoroutine("MakePlayerImmune");

    }
    IEnumerator MakePlayerImmune()
    {
        isImmune = true;
        yield return new WaitForSeconds(3);
        isImmune = false;
    }
    void Visibility()
    {
        StartCoroutine("SwitchVisibility");
    }
    IEnumerator SwitchVisibility()
    {
        visibilityActive = true;
        material.color = normalColor;
        yield return new WaitForSeconds((float)0.2);
        material.color= immuneColor;
        yield return new WaitForSeconds((float)0.2);
        visibilityActive = false;
    }
}
