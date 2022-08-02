using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : Obstacle
{
    public int obstacleSpeedSide, obstacleSpeedForward;

    public bool moveLeft, moveSide, moveForward;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (obstacleSpeedSide == 0) obstacleSpeedSide = 1;
        if(obstacleSpeedForward == 0) obstacleSpeedForward = 8;
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();
        MoveObstacle();
    }

    void MoveObstacle()
    {
        if (moveSide) MoveObstacleSides();
        if (moveForward) MoveObstacleForward();
    }
    void MoveObstacleForward()
    {
        if (transform.position.x - player.transform.position.x < 20 && transform.position.x - player.transform.position.x > -20) transform.position = transform.position + (new Vector3(-1, 0, 0) * obstacleSpeedForward * Time.deltaTime);
    }
    void MoveObstacleSides()
    {
        if (transform.position.z > -2 && moveLeft)
        {
            transform.position = transform.position + (new Vector3(0, 0, -1) * obstacleSpeedSide * Time.deltaTime);
            moveLeft = true;
        }
        else moveLeft = false;

        if (transform.position.z < 2 && !moveLeft)
        {
            transform.position = transform.position + (new Vector3(0, 0, 1) * obstacleSpeedSide * Time.deltaTime);
            moveLeft = false;
        }
        else moveLeft = true;
    }

}
