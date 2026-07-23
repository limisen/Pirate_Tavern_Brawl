using UnityEngine;
using UnityEngine.Rendering;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera camera_TableView;
    [SerializeField] Camera camera_TopDown;
    [SerializeField] Camera camera_BarView;
    [SerializeField] GameObject BarButtons;

    public string currentCamera;
    public void SwitchToCamera(string CameraToSwitchTo = "TableView")
    {
        if (CameraToSwitchTo == "TableView" || currentCamera == "TableCamera")
        {
            camera_TopDown.enabled = false;
            camera_BarView.enabled = false;

            camera_TableView.enabled = true;
            currentCamera = "TableCamera";
        }
        else if (CameraToSwitchTo == "TopDown" || currentCamera == "TopCamera")
        {
            camera_TableView.enabled = false;
            camera_BarView.enabled = false;

            camera_TopDown.enabled = true;
            currentCamera = "TopCamera";
        }
        else if (CameraToSwitchTo == "BarView" || currentCamera == "BarCamera")
        {
            camera_TopDown.enabled = false;
            camera_TableView.enabled = false;

            camera_BarView.enabled = true;
            currentCamera = "BarCamera";
            BarButtons.gameObject.SetActive(false);
        }
    }
}