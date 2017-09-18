using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{

    [SerializeField] private Transform leftBoundary;
    [SerializeField] private Transform rightBoundary;
    [SerializeField] private Transform upBoundary;
    [SerializeField] private Transform downBoundary;

    private float leftBoundaryF;
    private float rightBoundaryF;
    private float upBoundaryF;
    private float downBoundaryF;

    private Rigidbody2D rigidbody2D;
    private PlatformPlayerController player;

    void Awake()
    {
        leftBoundaryF = leftBoundary.position.x;
        rightBoundaryF = rightBoundary.position.x;
        upBoundaryF = upBoundary.position.y;
        downBoundaryF = downBoundary.position.y;

        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<PlatformPlayerController>();
    }

    public void CheckXY()
    {
        CheckX();
        CheckY();
    }

    private void CheckX()
    {
        if (((transform.position.x > rightBoundaryF) && (player.horizontalMove > 0)) ||
                    ((transform.position.x < leftBoundaryF) && (player.horizontalMove < 0)))
        {
            player.horizontalMove = 0;
        }
        else
        {
            player.horizontalMove = Input.GetAxis("Horizontal");
        }
    }

    private void CheckY()
    {
        if (transform.position.y < downBoundaryF)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
    }
}
