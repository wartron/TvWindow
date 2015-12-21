using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SteroCamera : MonoBehaviour
{

    public Camera cameraLeft;
    public Camera cameraRight;

    public Matrix4x4 leftProjection;
    public Matrix4x4 rightProjection;

    public float defaultCameraSpread = 0.05f;
    public float cameraSpread;
    public bool flipEyes = false;

    public float hScale = 0.005f;
    public float vScale = 0.00005f;

    public Text labelDepth;

    // Use this for initialization
    void Start()
    {
        cameraSpread = defaultCameraSpread;

        leftProjection = cameraLeft.projectionMatrix;
        rightProjection = cameraRight.projectionMatrix;

        //leftProjection.m11 = 2.5f;
        //rightProjection.m11 = 2.5f;

        leftProjection.m00 = 1.4f;
        rightProjection.m00 = 1.4f;

        cameraLeft.projectionMatrix = leftProjection;
        cameraRight.projectionMatrix = rightProjection;

        adjustDepth();

    }

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
        
        //cameraLeft.projectionMatrix = leftProjection;



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


        labelDepth.text = string.Format("3D Depth: {0:F6}", cameraSpread);


    }

}
