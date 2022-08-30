using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    GameObject player;
    Vector3 movement, currentMovement, startPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = new Vector3(0, (float)0.00001, 0);
        currentMovement = new Vector3(0, (float)0.0005, 0);
        startPosition = new Vector3(transform.position.x, (float)1.2, transform.position.z);
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            player.GetComponent<Scoring>().IncreaseScore(100);
            player.GetComponent<Scoring>().IncreaseAmountOfPickupsCollected();
        }
    }
    
    private void Move()
    {
        if (transform.position.y > 1.2) currentMovement -= movement;
        else  if (transform.position.y < 1) currentMovement += movement;
        

        transform.position += currentMovement;
        
    }
}
