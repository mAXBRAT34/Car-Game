using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float maxZoom = 300f;
    public float minZoom = 150f;
    public float followSpeed = 5f;
    Vector3 bottomLeft, topRight;
    float cameraMaxX, cameraMaxY, cameraMinX, cameraMinY, x, y;
    public Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        topRight = cam.ScreenToWorldPoint(new Vector3(
            cam.pixelWidth, cam.pixelHeight, -transform.position.z));
        bottomLeft = cam.ScreenToWorldPoint(new Vector3(
            0, 0, -transform.position.z));

        cameraMaxX = topRight.x;
        cameraMaxY = topRight.y;
        cameraMinX = bottomLeft.x;
        cameraMinY = bottomLeft.y;


    }

    void Update()
    {
        x = Input.GetAxis("Mouse X") * followSpeed;
        y = Input.GetAxis("Mouse Y") * followSpeed;
        transform.Translate(x, y, 0);

        if (Input.GetAxis("Mouse ScrolWheel") > 0 &&
            cam.orthographicSize > minZoom)
        {
            cam.orthographicSize = cam.orthographicSize - 50f;
        }

        if (Input.GetAxis("Mouse ScrolWheel") < 0 &&
            cam.orthographicSize > minZoom)
        {
            cam.orthographicSize = cam.orthographicSize + 50f;
        }
    }
}