using UnityEngine;
using UnityEngine.InputSystem;

public class CardPicker : MonoBehaviour
{
    private bool CardSelect = false;
    private Vector3 startLocalScale;
    private Vector3 startLocalPosition;
    private Quaternion startLocalRotation;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;

    }

    private void Update()
    {
        if (CardSelect)
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.transform.localPosition = cam.ScreenToWorldPoint(new Vector3((Mouse.current.position.ReadValue().x - 35), (Mouse.current.position.ReadValue().y + 350), 11));
        }
    }

    void OnMouseDown()
    {
        if (CardSelect == false)
        {
            CardSelect = true;
            Debug.Log("Mouse clicked on: " + gameObject.name);
            if (startLocalPosition == Vector3.zero)
            {
                Debug.Log("StartingValues: " + startLocalPosition + ", " + startLocalRotation + ", " + startLocalScale);
                startLocalScale = transform.localScale;
                startLocalPosition = transform.localPosition;
                startLocalRotation = transform.localRotation;
            }
        }
    }
    private void OnMouseUp()
    {
        Debug.Log("StartingValues: " + startLocalPosition + ", " + startLocalRotation + ", " + startLocalScale);
        CardSelect = false;
        cardManipulation();
    }
    void cardManipulation()
    {
        if (CardSelect == true)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            gameObject.transform.localPosition = cam.ScreenToWorldPoint(new Vector3((Mouse.current.position.ReadValue().x - 35), (Mouse.current.position.ReadValue().y + 350), 11));
        }
        else if (CardSelect == false)
        {
            gameObject.transform.localScale = startLocalScale;
            gameObject.transform.localPosition = startLocalPosition;
            gameObject.transform.localRotation = startLocalRotation;
        }
    }
}
