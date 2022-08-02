using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") SwitchToFinish();
    }

    void SwitchToFinish()
    {
        SceneManager.LoadScene(2);
    }
}
