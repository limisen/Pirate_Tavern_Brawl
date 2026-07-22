using UnityEngine;
using UnityEngine.Rendering;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera camera_TableView;
    [SerializeField] Camera camera_TopDown;
    [SerializeField] Camera camera_BarView;
    [SerializeField] GameObject BarButtons;
    UserInterface userInterface;

    public string currentCamera = "TableCamera";
    public void Start()
    {
        userInterface = GetComponent<UserInterface>();
    }
    public void SwitchToCamera(string CameraToSwitchTo = "TableView")
    {
        if (CameraToSwitchTo == "TableView")
        {
            camera_TopDown.enabled = false;
            camera_BarView.enabled = false;

            camera_TableView.enabled = true;
            currentCamera = "TableCamera";
        }
        else if (CameraToSwitchTo == "TopDown")
        {
            camera_TableView.enabled = false;
            camera_BarView.enabled = false;

            camera_TopDown.enabled = true;
            currentCamera = "TopCamera";
            BarButtons.gameObject.SetActive(false);
        }
        else if (CameraToSwitchTo == "BarView")
        {
            camera_TopDown.enabled = false;
            camera_TableView.enabled = false;

            camera_BarView.enabled = true;
            currentCamera = "BarCamera";
        }
    }
}