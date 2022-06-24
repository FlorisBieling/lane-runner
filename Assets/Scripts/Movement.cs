using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;

    bool moveLeft, moveRight, jump, grounded = true;

    Vector3 jumpForce = new Vector3(0, 250, 0);

    public int speed;


    // Start is called before the first frame update
    void Start()
    {
        ResetSpeed();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        print(grounded);

        player.transform.position = player.transform.position + (new Vector3(1, 0, 0) * speed * Time.deltaTime);
        GetInput();
        DoMovement();
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
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor") grounded = false;
    }
}
