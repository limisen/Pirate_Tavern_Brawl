using UnityEngine;

public class CardClass : MonoBehaviour
{
    public enum Conditions
    {
        none, No_Attacks, No_Defends
    }
    public string Name_Of_Card;
    public int Cost_of_Card;
    public Sprite Card_front;
    public Sprite Card_Back;
    public string Card_Description;
    public Conditions condition;
    public bool cardNoInteract = false;
}