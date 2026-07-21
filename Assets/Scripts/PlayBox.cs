using UnityEngine;

public class PlayBox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Card"))
        {
            collision.GetComponent<CardInteract>().is_in_playbox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Card"))
        {
            collision.GetComponent<CardInteract>().is_in_playbox = false;
        }
    }
}
