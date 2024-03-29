using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    public int damage;
    virtual public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (damage == 0) damage = 1;
    }

    // Update is called once per frame
    virtual public void Update()
    {

    }

    private void TurnOffCollision()
    {
        GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!player.GetComponent<Damage>().isImmune)
            {
            StartCoroutine("SlowDown");
            player.GetComponent<Damage>().TakeDamage(damage);
            }
            TurnOffCollision();
        }
    }
    IEnumerator SlowDown()
    {
        player.GetComponent<Movement>().speed = player.GetComponent<Movement>().speed / 2;
        yield return new WaitForSeconds(2);
        player.GetComponent<Movement>().ResetSpeed();
    }

    
}
