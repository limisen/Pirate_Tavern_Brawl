using UnityEngine;

public class OnMouseHover : MonoBehaviour
{
    private bool onCard = false;
    private Vector3 startLocalPosition;
    private Quaternion startLocalRotation;
    private Vector3 startLocalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseOver()
    {
        if (!onCard)
        {
            onCard = true;
            Debug.Log("Mouse is over gameObject"+ gameObject.name);
            startLocalPosition = transform.localPosition;
            startLocalRotation = transform.localRotation;
            startLocalScale = transform.localScale;
            cardInformation();
        }
    }

    void OnMouseExit()
    {
        onCard = false;
        Debug.Log("Mouse is not over gameObject");
        cardInformation();
        
    }

    void cardInformation()
    {
        if (onCard == true)
        {

            gameObject.transform.localScale = new Vector3(1.5f, 1.0f, 1);
            gameObject.transform.localPosition = new Vector3(0, 0.34f, 0);
            //gameObject.transform.localRotation = Quaternion.identity;
        }
        else if (onCard == false)
        {
            gameObject.transform.localScale = startLocalScale;
            gameObject.transform.localPosition = startLocalPosition;
            gameObject.transform.localRotation = startLocalRotation; 
        }
    }
}
