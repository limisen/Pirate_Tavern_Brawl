using UnityEngine;
using UnityEngine.Rendering;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera camera_TableView;
    [SerializeField] Camera camera_TopDown;
    [SerializeField] Camera camera_BarView;
    [SerializeField] GameObject BarButtons;

    public string currentCamera;
    public void SwitchToCamera(string CameraToSwitchTo)
    {

        camera_TopDown.gameObject.SetActive(false);
        camera_TableView.gameObject.SetActive(false);
        camera_BarView.gameObject.SetActive(false);

        if (CameraToSwitchTo == "TableView")
        {
            camera_TopDown.enabled = false;
            camera_BarView.enabled = false;

            camera_TableView.enabled = true;
            camera_TableView.gameObject.SetActive(true);
            currentCamera = "TableCamera";
        }
        else if (CameraToSwitchTo == "TopDown")
        {
            camera_TableView.enabled = false;
            camera_BarView.enabled = false;

            camera_TopDown.enabled = true;
            camera_TopDown.gameObject.SetActive(true);
            currentCamera = "TopCamera";
        }
        else if (CameraToSwitchTo == "BarView")
        {
            camera_TopDown.enabled = false;
            camera_TableView.enabled = false;

            camera_BarView.enabled = true;
            camera_BarView.gameObject.SetActive(true);
            currentCamera = "BarCamera";
            BarButtons.gameObject.SetActive(false);
        }
        Debug.Log("Current Camera: " + currentCamera);
    }
}