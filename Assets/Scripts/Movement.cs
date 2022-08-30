using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;

    bool moveLeft, moveRight, jump, grounded = true, startGame = false, doOnce = true, doOnceAuto = true;

    public static Vector3 jumpForce = new Vector3(0, 250, 0);

    public int speed;

    public bool canMove = true;

    int waitBeforeStart = 3;

    public int totalDistance, totalAmountOfJumps;
    public static int totalDistanceS, totalAmountOfJumpsS;




    // Start is called before the first frame update
    void Start()
    {
        ResetSpeed();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("WaitOnStart");
    }

    // Update is called once per frame
    void Update()
    {
        totalDistance = player.GetComponent<Scoring>().totalDistance;
        totalDistanceS = totalDistance;
        totalAmountOfJumpsS = totalAmountOfJumps;
        if (Time.timeSinceLevelLoad > 3 && canMove)
        {
            GetInput();
            AutoCompleteLevel();
            player.transform.position = player.transform.position + (new Vector3(1, 0, 0) * speed * Time.deltaTime);
            DoMovement();
        }
    }

    void DoMovement()
    {
        if (moveLeft && player.transform.position.z < 2)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 2);
        }
        if (moveRight && player.transform.position.z > -2)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 2);
        }
        if (jump && grounded)
        {
            player.GetComponent<Rigidbody>().AddForce(jumpForce);
            totalAmountOfJumps++;
        }
    }
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) jump = true;
        else jump = false;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) moveLeft = true;
        else moveLeft = false;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) moveRight = true;
        else moveRight = false;
    }

    public void ResetSpeed()
    {
        speed = 4;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor") grounded = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Floor") grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor") grounded = false;
    }

    IEnumerator WaitOnStart()
    {
        new WaitForSeconds(waitBeforeStart);
        yield return null;
        startGame = true;
    }

    public void AutoCompleteLevel()
    {
        //completes level with all lives and all pickups
        if (totalDistance == 11) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 19) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 21) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 26) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 33) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 39) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 44) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 62) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 64) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 66) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 72) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 74) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 78) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 80) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 83) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 93) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 100) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 105) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 110) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 112) { if (doOnceAuto) { jump = true; doOnceAuto = false; } }
        else if (totalDistance == 118) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 125) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 130) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 135) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 147) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 150) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 152) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else if (totalDistance == 159) { if (doOnceAuto) { moveLeft = true; doOnceAuto = false; } }
        else if (totalDistance == 171) { if (doOnceAuto) { moveRight = true; doOnceAuto = false; } }
        else { doOnceAuto = true; moveLeft = false; moveRight = false; jump = false; }
    }
}
