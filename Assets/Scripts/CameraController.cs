using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

//Author : Hamed Safaei
public class CameraController : MonoBehaviour
{
    public float defaultY = 0;
    public GameObject player;
    public int cameraHorizontalPositionProportion = 3;
    public int cameraVerticalPositionProportion = 4;
    public float horizontalTransitionTime = 5;
    public float verticalTransitionTime = 5;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    private PlatformerCharacter2D playerScript;

    private float screenHeight;
    private float screenWidth;
    private float horizontalProportion;
    private bool cameraInRight = false;
    private bool cameraMoovingHorizontally = false;
    private bool cameraMoovingVertically = false;
    private float targetX;
    private float targetY;

    void Start()
    {
        playerScript = player.GetComponent<PlatformerCharacter2D>();
        horizontalProportion = cameraHorizontalPositionProportion*2;
        screenHeight = Camera.main.orthographicSize * 2.0f;
        screenWidth = screenHeight * Screen.width / Screen.height;
    }

    void Update()
    {
        if ((player.transform.position.y > (screenHeight/cameraVerticalPositionProportion)) &&  transform.position.y == 0)
        {
            cameraMoovingVertically = true;
            StartCoroutine(MoveCameraVerticcaly(verticalTransitionTime));
        }
        else if ((transform.position.y != 0) && (player.transform.position.y > 0) && !cameraMoovingVertically)
        {
            targetY = player.transform.position.y;
        }

        if ((playerScript.m_FacingRight && !cameraInRight))
        {
            if (cameraMoovingHorizontally)
            {
                StopAllCoroutines();
                cameraMoovingHorizontally = false;
            }
            cameraMoovingHorizontally = true;
            StartCoroutine(MoveCameraHorizontally(true, horizontalTransitionTime));
            cameraInRight = true;
        }else if (!playerScript.m_FacingRight && cameraInRight)
        {
            if (cameraMoovingHorizontally)
            {
                StopAllCoroutines();
                cameraMoovingHorizontally = false;
            }
            cameraMoovingHorizontally = true;
            StartCoroutine(MoveCameraHorizontally(false, horizontalTransitionTime));
            cameraInRight = false;
        }
        else
        {
            if (!cameraMoovingHorizontally)
            {
                targetX = player.transform.position.x + (playerScript.m_FacingRight ? (screenWidth / horizontalProportion) : -(screenWidth / horizontalProportion));
            }            
        }

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
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
