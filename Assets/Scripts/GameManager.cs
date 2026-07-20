using UnityEngine;
using static CardClass;

public class GameManager : MonoBehaviour
{
    GameLoop Encounter_Loop;
    [SerializeField] GameObject AttackCardPrefab;
    [SerializeField] GameObject DefenceCardPrefab;
    [SerializeField] GameObject SpecialCardPrefab;

    public int coins_Available = 50;
    public int costs_Of_Card = 3;
    public int player_HP = 30;
    public int opponent_HP = 30;

    private void Main()
    {
        // start of Encounter

        // Create the list of cards

        for (int i = 0; i < 8; i++)
        {
            if (i <= 3)
            {
                GameObject Card = Instantiate(AttackCardPrefab);

                AttackCard attackCard = Card.GetComponent<AttackCard>();
                attackCard.Name_Of_Card = "Attack_Card_" + i.ToString();
                Card.name = attackCard.Name_Of_Card;

                attackCard.Cost_of_Card = costs_Of_Card;

                //attackCard.Card_Portrait = Sprite new sprite;

                attackCard.Card_Description = "blabla bla";

                attackCard.condition = Conditions.none;
            }
            else if (i > 3 && i <= 6)
            {
                GameObject Card = Instantiate(DefenceCardPrefab);

                DefenceCard defenceCard = Card.GetComponent<DefenceCard>();
                defenceCard.Name_Of_Card = "Defence_Card_" + i.ToString();
                Card.name = defenceCard.Name_Of_Card;

                defenceCard.Card_Description = "Bla Bla Bla";

                defenceCard.condition = Conditions.none;
            }
            else if (i > 6 && i <= 8)
            {
                GameObject Card = Instantiate(SpecialCardPrefab);

                SpecialCard specialCard = Card.GetComponent<SpecialCard>();
                specialCard.Name_Of_Card = "Defence_Card_" + i.ToString();
                Card.name = specialCard.Name_Of_Card;

                specialCard.Card_Description = "Bla Bla Bla";

                specialCard.condition = Conditions.No_Attacks;
            }
        }
    }
}
