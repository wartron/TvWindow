using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SteroCamera : MonoBehaviour
{

    public Camera cameraLeft;
    public Camera cameraRight;


    public float cameraSpread = 0.1f;

    public bool flipEyes = false;

    //TODO: Move outside camera
    public float hScale = 0.005f;
    public float vScale = 0.00005f;
    public Text labelDepth;



    void Start()
    {
        adjustProjection();
        adjustDepth();
    }

    //TODO: Move outside camera
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0)
        {
            cameraSpread += h * hScale;
            adjustDepth();
        }

        if (v != 0)
        {
            cameraSpread += v * vScale;
            adjustDepth();
        }

    }

    void adjustProjection()
    {
        Matrix4x4 leftProjection = cameraLeft.projectionMatrix;
        Matrix4x4 rightProjection = cameraRight.projectionMatrix;

        if (true) //hsbs
        {
            leftProjection.m00 = leftProjection.m00 / 2.0f;
            rightProjection.m00 = rightProjection.m00 / 2.0f;

        }
        else //h-ov
        {
            leftProjection.m11 = leftProjection.m11 / 2.0f;
            rightProjection.m11 = rightProjection.m11 / 2.0f;

        }

        cameraLeft.projectionMatrix = leftProjection;
        cameraRight.projectionMatrix = rightProjection;

    }

    void adjustDepth()
    {
        float hs = cameraSpread / 2.0f;

        float leftX = hs;
        float rightX = hs;

        if (flipEyes)
        {
            rightX *= -1;
        }
        else
        {
            leftX *= -1;

        }


        cameraLeft.transform.localPosition = new Vector3(leftX, 0, 0);
        cameraRight.transform.localPosition = new Vector3(rightX, 0, 0);

        //TODO: Move outside camera
        labelDepth.text = string.Format("3D Depth: {0:F6}", cameraSpread);


    }

}
