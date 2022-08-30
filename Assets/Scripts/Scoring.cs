using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    GameObject score, distance, pickups, player;

    public int totalScore, totalDistance, totalPickups;
    public static int totalScoreS, totalDistanceS, totalPickupsS;
    private float lastTime;
    Vector3 startPosition, lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
        distance = GameObject.FindGameObjectWithTag("Distance");
        pickups = GameObject.FindGameObjectWithTag("Pickups");
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
        lastPosition = player.transform.position;
        totalPickupsS = totalPickups;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseScoreWithDistance();
        score.GetComponent<UnityEngine.UI.Text>().text = "Score: " + totalScore.ToString();
        distance.GetComponent<UnityEngine.UI.Text>().text = "Distance: " + totalDistance.ToString();
        pickups.GetComponent<UnityEngine.UI.Text>().text = "Pickups: " + totalPickups.ToString();
    }

    public void IncreaseScore(int score)
    {
        totalScore += score;
    }

    private void IncreaseScoreWithDistance()
    {
        if (gameObject.transform.position.x > lastPosition.x + 1)
        {
            totalDistance++;
            totalScore++;
            lastPosition = gameObject.transform.position;
        }
    }
    public void IncreaseAmountOfPickupsCollected()
    {
        totalPickups++;
        totalPickupsS++;
    }
}
