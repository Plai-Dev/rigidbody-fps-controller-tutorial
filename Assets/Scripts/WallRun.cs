using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    [SerializeField] private Transform orientation;

    [Header("Wall Running")]
    [SerializeField] private float wallDistance = .5f;
    [SerializeField] private float minimumJumpHeight = 1.5f;

    private bool wallLeft = false;
    private bool wallRight = false;

    bool CanWallRun()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minimumJumpHeight);
    }

    void CheckWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, wallDistance);
        wallRight = Physics.Raycast(transform.position, orientation.right, wallDistance);
    }

    private void Update()
    {
        CheckWall();

        if (CanWallRun())
        {
            if (wallLeft)
            {
                Debug.Log("wall running on the left");
            }
            else if (wallRight)
            {
                Debug.Log("wall running on the right");
            }
        }
    }
}