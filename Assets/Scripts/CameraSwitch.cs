using UnityEngine;
using UnityEngine.Rendering;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Camera camera_TableView;
    [SerializeField] Camera camera_TopDown;
    [SerializeField] Camera camera_BarView;
    [SerializeField] Camera camera_TitleScreen;
    [SerializeField] Camera camera_CreditsScreen;
    [SerializeField] GameObject coin_purse;
    [SerializeField] GameObject TableView;
    [SerializeField] GameObject TopDownView;
    [SerializeField] GameObject BarView;
    [SerializeField] GameObject TitleView;
    [SerializeField] GameObject CreditsView;
 
    public string currentCamera;
    public void SwitchToCamera(string CameraToSwitchTo)
    {

        camera_TableView.gameObject.SetActive(false);
        TableView.gameObject.SetActive(false);

        camera_TopDown.gameObject.SetActive(false);
        TopDownView.gameObject.SetActive(false);

        camera_BarView.gameObject.SetActive(false);
        BarView.gameObject.SetActive(false);

        camera_TitleScreen.gameObject.SetActive(false);
        TitleView.gameObject.SetActive(false);

        coin_purse.gameObject.SetActive(false);
        
        camera_CreditsScreen.gameObject.SetActive(false);
        CreditsView.gameObject.SetActive(false);

        if (CameraToSwitchTo == "TableView")
        {
            coin_purse.gameObject.SetActive(true);

            camera_TableView.enabled = true;
            camera_TableView.gameObject.SetActive(true);
            currentCamera = "TableCamera";
            TableView.gameObject.SetActive(true);
        }
        else if (CameraToSwitchTo == "TopDown")
        {
            camera_TopDown.enabled = true;
            camera_TopDown.gameObject.SetActive(true);
            currentCamera = "TopCamera";
            TopDownView.gameObject.SetActive(true);
        }
        else if (CameraToSwitchTo == "BarView")
        {
            coin_purse.gameObject.SetActive(true);

            camera_BarView.enabled = true;
            camera_BarView.gameObject.SetActive(true);
            currentCamera = "BarCamera";
            BarView.gameObject.SetActive(true);
        }
        else if (CameraToSwitchTo == "TitleView")
        {
            camera_TitleScreen.enabled = true;
            camera_TitleScreen.gameObject.SetActive(true);
            currentCamera = "TitleCamera";
            TitleView.gameObject.SetActive(true);
        }

        else if (CameraToSwitchTo == "CreditsView")
        {
            camera_CreditsScreen.enabled = true;
            camera_CreditsScreen.gameObject.SetActive(true);
            currentCamera = "CreditsCamera";
            CreditsView.gameObject.SetActive(true);
        }

        Debug.Log("Current Camera: " + currentCamera);
    }
}