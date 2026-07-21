using UnityEngine;
using static CardClass;

public class GameManager : MonoBehaviour
{
    GameLoop Encounter_Loop;
    [SerializeField] GameObject ParentObject;
    [SerializeField] GameObject AttackCardPrefab;
    [SerializeField] GameObject DefenceCardPrefab;
    [SerializeField] GameObject SpecialCardPrefab;

    public int coins_Available = 50;
    public int costs_Of_Card = 3;
    public int player_HP = 30;
    public int opponent_HP = 30;

    private void Start()
    {
        // start of Encounter
        coins_Available = 50; 
        costs_Of_Card = 3;
        player_HP = 30;
        opponent_HP = 30;
        // Create the list of cards
        for (int i = 0; i < 8; i++)
        {
            if (i <= 2)
            {
                GameObject Card = Instantiate(AttackCardPrefab,ParentObject.transform);

                AttackCard attackCard = Card.GetComponent<AttackCard>();
                attackCard.Name_Of_Card = "Attack_Card_" + i.ToString();
                Card.name = attackCard.Name_Of_Card;

                attackCard.Cost_of_Card = costs_Of_Card;

                //attackCard.Card_Portrait = Sprite new sprite;

                attackCard.Card_Description = "blabla bla";

                attackCard.Damage = Random.Range(1,4);

                attackCard.condition = Conditions.none;
            }
            else if (i > 2 && i <= 5)
            {
                GameObject Card = Instantiate(DefenceCardPrefab,ParentObject.transform);

                DefenceCard defenceCard = Card.GetComponent<DefenceCard>();
                defenceCard.Name_Of_Card = "Defence_Card_" + i.ToString();
                Card.name = defenceCard.Name_Of_Card;

                defenceCard.Cost_of_Card = costs_Of_Card;

                defenceCard.Card_Description = "Bla Bla Bla";

                defenceCard.Defence_Value = Random.Range(1, 4);

                defenceCard.condition = Conditions.none;
            }
            else if (i > 5 && i <= 8)
            {
                GameObject Card = Instantiate(SpecialCardPrefab,ParentObject.transform);

                SpecialCard specialCard = Card.GetComponent<SpecialCard>();
                specialCard.Name_Of_Card = "Special_Card_" + i.ToString();
                Card.name = specialCard.Name_Of_Card;

                specialCard.Cost_of_Card = costs_Of_Card;

                specialCard.Card_Description = "Bla Bla Bla";

                specialCard.condition = Conditions.No_Attacks;
            }
        }
    }
}
