using UnityEngine;

public class OnMouseHover : MonoBehaviour
{
    private bool onCard = false;
    private Vector3 startLocalScale;
    private Vector3 startLocalPosition;
    private Quaternion startLocalRotation;

    void OnMouseOver()
    {
        if (onCard == false)
        {
            onCard = true;
            //Debug.Log("Mouse is over gameObject"+ gameObject.name);
            startLocalScale = transform.localScale;
            startLocalPosition = transform.localPosition;
            startLocalRotation = transform.localRotation;
            cardInformation();
        }
    }

    void OnMouseExit()
    {
        onCard = false;
        //Debug.Log("Mouse is not over gameObject");
        cardInformation();
    }

    void cardInformation()
    {
        if (onCard == true)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.0f, 1);
            gameObject.transform.localPosition = new Vector3(0, 0.34f, 0);
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (onCard == false)
        {
            gameObject.transform.localScale = startLocalScale;
            gameObject.transform.localPosition = startLocalPosition;
            gameObject.transform.localRotation = startLocalRotation; 
        }
    }
}
