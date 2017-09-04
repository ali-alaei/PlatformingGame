using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CameraController : MonoBehaviour
{
    public float defaultY = 0;
    public GameObject player;
    public int cameraHorizontalPositionProportion = 3;
    public int cameraVerticalPositionProportion = 4;
    public float horizontalTransitionTime = 5;
    public float verticalTransitionTime = 5;

    private PlatformerCharacter2D playerScript;

    private float screenHeight;
    private float screenWidth;
    private float horizontalProportion;
    private bool cameraInRight = false;
    private bool cameraMoovingHorizontally = false;
    private bool cameraMoovingVertically = false;

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
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
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
                transform.position = new Vector3(player.transform.position.x + (playerScript.m_FacingRight ? (screenWidth / horizontalProportion) : -(screenWidth / horizontalProportion)), transform.position.y, transform.position.z);
            }            
        }

        
    }

    IEnumerator MoveCameraHorizontally(bool moveRight, float time)
    {
        float value;
        float rate = 1.0f/time;
        float i = 0.0f;
        while (i <= 1)
        {
            i += rate*Time.deltaTime;
            if(moveRight)
                value = Mathf.Lerp(transform.position.x, player.transform.position.x + screenWidth / horizontalProportion, i);
            else
                value = Mathf.Lerp(transform.position.x, player.transform.position.x - screenWidth / horizontalProportion, i);
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
            yield return null;
        }
        cameraMoovingHorizontally = false;
        if(moveRight)
            transform.position = new Vector3(player.transform.position.x + screenWidth / horizontalProportion, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(player.transform.position.x - screenWidth / horizontalProportion, transform.position.y, transform.position.z);
    }

    IEnumerator MoveCameraVerticcaly(float time)
    {
        float value;
        float rate = 1.0f / time;
        float i = 0.0f;
        while (i <= 1)
        {
            i += rate * Time.deltaTime;
            value = Mathf.Lerp(transform.position.y, player.transform.position.y, i);
            transform.position = new Vector3(transform.position.x, value, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        cameraMoovingVertically = false;
    }
}
