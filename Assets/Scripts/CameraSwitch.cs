using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera camera_self;
    [SerializeField] Camera camera_other;

    public void SwitchToCameraFromCamera(Camera camera_self, Camera camera_other)
    {
        if (camera_self.enabled == true)
        {
            camera_other.enabled = true;
            camera_self.enabled = false;
        } else if (camera_self.enabled == false)
        {
            camera_self.enabled = true;
            camera_other.enabled = false;
        }
    }
}
