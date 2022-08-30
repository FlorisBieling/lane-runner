using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //SwitchToFinish();
            player.GetComponent<Movement>().canMove = false;
        }
    }

    void SwitchToFinish()
    {
        SceneManager.LoadScene(2);
    }
}
