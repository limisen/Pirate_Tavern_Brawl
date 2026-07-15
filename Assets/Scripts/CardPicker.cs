using UnityEngine;
using UnityEngine.InputSystem;

public class CardPicker : MonoBehaviour
{
    private bool onCardSelect = false;
    private Vector3 startLocalScale;
    private Vector3 startLocalPosition;
    private Quaternion startLocalRotation;

    void OnMouseDown()
    {
        if (onCardSelect == false)
        {
            onCardSelect = true;
            Debug.Log("Mouse clicked on: "+ gameObject.name);
            startLocalScale = transform.localScale;
            startLocalPosition = transform.localPosition;
            startLocalRotation = transform.localRotation;
            cardManipulation();
        }
    }
    private void OnMouseUp()
    {
        onCardSelect = false;
        cardManipulation();
    }

    private void Update()
    {
        cardManipulation();
    }
    void cardManipulation()
    {
        if (onCardSelect == true)
        {
            gameObject.transform.localPosition = new Vector3(Mouse.current.position.ReadValue().x ,Mouse.current.position.ReadValue().x, 1);
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (onCardSelect == false)
        {
            gameObject.transform.localScale = startLocalScale;
            gameObject.transform.localPosition = startLocalPosition;
            gameObject.transform.localRotation = startLocalRotation;
        }
    }
}
