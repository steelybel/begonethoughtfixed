using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float startSpeed = 3f;
   
    Player player;
    Vector3 forward, right;
    public string xAxis, yAxis, button;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(xAxis) != 0 || Input.GetAxis(yAxis) != 0)
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis(xAxis), 0, Input.GetAxis(yAxis));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis(xAxis);
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis(yAxis);

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //combo of right and upmovement rotated
        transform.forward = heading;

        transform.position += rightMovement;
        transform.position += upMovement;
    }

}

