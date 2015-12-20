using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SteroCamera : MonoBehaviour {

    public Camera cameraLeft;
    public Camera cameraRight;

    public float defaultCameraSpread = 0.2f;
    public float cameraSpread;
    public bool flipEyes = false;

    public float hScale = 0.005f;
    public float vScale = 0.0005f;

    public Text labelDepth;

	// Use this for initialization
	void Start () {

        cameraSpread = defaultCameraSpread;

        adjustDepth();

	}
	
	// Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h != 0)
        {
            cameraSpread += h * hScale;

            adjustDepth();
        }



        float v = Input.GetAxis("Vertical");

        if (v != 0)
        {
            cameraSpread += v * vScale;

            adjustDepth();
        }



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
