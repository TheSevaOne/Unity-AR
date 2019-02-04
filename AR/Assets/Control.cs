using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Vuforia;
public class Control : MonoBehaviour   {
    private Rigidbody rb;
    [SerializeField]
    private float speed=2f;
	void Start () {
      
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
		float y = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 moverment = new Vector3(x, 0, y);
        rb.velocity = moverment * speed;
        if (x != 0 && y != 0)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,Mathf.Atan2(x,y)+Mathf.Rad2Deg, transform.eulerAngles.z );

    }
   
}
public class PhoneCamera : MonoBehaviour
{
    public void OnCameraChangeMode()
    {
        Vuforia.CameraDevice.CameraDirection currentDir = Vuforia.CameraDevice.Instance.GetCameraDirection();


        RestartCamera(Vuforia.CameraDevice.CameraDirection.CAMERA_FRONT);



    }


  
    private void RestartCamera(Vuforia.CameraDevice.CameraDirection newDir)
    {
        Vuforia.CameraDevice.Instance.Stop();
        Vuforia.CameraDevice.Instance.Deinit();
        Vuforia.CameraDevice.Instance.Init(newDir);
        Vuforia.CameraDevice.Instance.Start();
    }
}




