using UnityEngine;

public class PlayBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Card"))
        {
            collision.GetComponent<CardInteract>().is_in_playbox = true;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player_Play_Area"))
        {
            Debug.Log(gameObject.name);
            collision.GetComponent<CardClass>().cardNoInteract = false;
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