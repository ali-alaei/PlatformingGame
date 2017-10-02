using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

//Author : Hamed Safaei
public class CameraController : MonoBehaviour
{
    [SerializeField] private float defaultY = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private int cameraHorizontalPositionProportion = 3;
    [SerializeField] private int cameraVerticalPositionProportion = 4;
    [SerializeField] private float horizontalTransitionTime = 5;
    [SerializeField] private float verticalTransitionTime = 5;
    [SerializeField] private Transform leftBoundary;
    [SerializeField] private Transform rightBoundary;
    [SerializeField] private Transform upBoundary;
    [SerializeField] private Transform downBoundary;
    

    private PlayerMovement playerScript;

    private float screenHeight;
    private float screenWidth;
    private float horizontalProportion;
    private bool cameraInRight = false;
    private bool cameraMoovingHorizontally = false;
    private bool cameraMoovingVertically = false;
    private float targetX;
    private float targetY;
    private Vector2 maxXAndY;
    private Vector2 minXAndY;

    private Coroutine horizontalMoveCoroutine;

    void Start()
    {
        playerScript = player.GetComponent<PlayerMovement>();
        horizontalProportion = cameraHorizontalPositionProportion*2;
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight * Screen.width / Screen.height;

        maxXAndY = new Vector2(rightBoundary.position.x, upBoundary.position.y);
        minXAndY = new Vector2(leftBoundary.position.x, downBoundary.position.y);
    }

    void Update()
    {
        DetermineX();
        DetermineY();

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    private void DetermineX()
    {
        if ((playerScript.facingRight && !cameraInRight))
        {
            if (cameraMoovingHorizontally)
            {
                StopCoroutine(horizontalMoveCoroutine);
                cameraMoovingHorizontally = false;
            }
            cameraMoovingHorizontally = true;
            horizontalMoveCoroutine = StartCoroutine(MoveCameraHorizontally(true, horizontalTransitionTime));
            cameraInRight = true;
        }
        else if (!playerScript.facingRight && cameraInRight)
        {
            if (cameraMoovingHorizontally)
            {
                StopCoroutine(horizontalMoveCoroutine);
                cameraMoovingHorizontally = false;
            }
            cameraMoovingHorizontally = true;
            horizontalMoveCoroutine = StartCoroutine(MoveCameraHorizontally(false, horizontalTransitionTime));
            cameraInRight = false;
        }
        else
        {
            if (!cameraMoovingHorizontally)
            {
                targetX = player.transform.position.x + (playerScript.facingRight ? (screenWidth / horizontalProportion) : -(screenWidth / horizontalProportion));
            }
        }
    }

    private void DetermineY()
    {
        if ((player.transform.position.y > (screenHeight / cameraVerticalPositionProportion)) && transform.position.y == 0)
        {
            cameraMoovingVertically = true;
            StartCoroutine(MoveCameraVerticcaly(verticalTransitionTime));
        }
        else if ((transform.position.y != 0) && (player.transform.position.y > 0) && !cameraMoovingVertically)
        {
            targetY = player.transform.position.y;
        }
    }

    IEnumerator MoveCameraHorizontally(bool moveRight, float time)
    {
        float rate = 1.0f/time;
        float i = 0.0f;
        while (i <= 1)
        {
            i += rate*Time.deltaTime;
            if(moveRight)
                targetX = Mathf.Lerp(transform.position.x, player.transform.position.x + screenWidth / horizontalProportion, i);
            else
                targetX = Mathf.Lerp(transform.position.x, player.transform.position.x - screenWidth / horizontalProportion, i);
            yield return null;
        }
        cameraMoovingHorizontally = false;
        if (moveRight)
            targetX = player.transform.position.x + screenWidth/horizontalProportion;
        else
            targetX = player.transform.position.x + screenWidth / horizontalProportion;
    }

    IEnumerator MoveCameraVerticcaly(float time)
    {
        float rate = 1.0f / time;
        float i = 0.0f;
        while (i <= 1)
        {
            i += rate * Time.deltaTime;
            targetY = Mathf.Lerp(transform.position.y, player.transform.position.y, i);
            yield return null;
        }
        targetY = player.transform.position.y;
        cameraMoovingVertically = false;
    }
}
