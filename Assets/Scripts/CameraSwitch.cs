using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera camera_TableView;
    [SerializeField] Camera camera_TopDown;
    [SerializeField] Camera camera_BarView;

    public void SwitchToCamera(string CameraToSwitchTo = "TableView")
    {
        if (CameraToSwitchTo == "TableView")
        {
            camera_TopDown.enabled = false;
            camera_BarView.enabled = false;

            camera_TableView.enabled = true;
        }
        else if (CameraToSwitchTo == "TopDown")
        {
            camera_TableView.enabled = false;
            camera_BarView.enabled = false;

            camera_TopDown.enabled = true;
        }
        else if (CameraToSwitchTo == "BarView")
        {
            camera_TopDown.enabled = false;
            camera_TableView.enabled = false;

            camera_BarView.enabled = true;
        }
    }
}