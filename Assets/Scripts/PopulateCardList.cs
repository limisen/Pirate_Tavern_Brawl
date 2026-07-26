using System.Collections.Generic;
using UnityEngine;
using static CardClass;

public class PopulateCardList : MonoBehaviour
{
    // Where the cards will be instantiated as children of this object
    [SerializeField, Tooltip("The parent object used for when instantiatig cards. (Cards get instantiated as children of this object)")] public GameObject ParentObject;

    [SerializeField] GameObject AttackCardPrefab;
    [SerializeField] List<Sprite> AttackCardPortrait;

    [SerializeField] GameObject DefenceCardPrefab;
    [SerializeField] List<Sprite> DefenceCardPortrait;

    [SerializeField] GameObject SpecialCardPrefab;
    [SerializeField] List<Sprite> SpecialCardPortrait;

    public int costs_Of_Card = 3;
    public void PopulateCards()
    {
        // List of positons on the cardList for where the cards will be instantiated
        var positionsOnListOfCards = new Dictionary<int, Vector3>
        {
            [0] = new Vector3(0.56f, 0.47f, 0),
            [1] = new Vector3(2.7f, 0.47f, 0),
            [2] = new Vector3(4.82f, 0.47f, 0),
            [3] = new Vector3(0.6f, -2.5f, 0),
            [4] = new Vector3(2.67f, -2.57f, 0),
            [5] = new Vector3(4.77f, -2.52f, 0),
            [6] = new Vector3(0.6f, -5.44f, 0),
            [7] = new Vector3(2.7f, -5.48f, 0),
        };

        // Create the list of cards
        for (int i = 0; i < 8; i++)
        {
            // Randomly select a card type (0 = Attack, 1 = Defence, 2 = Special)
            int cardType = Random.Range(0, 3);

            if (cardType == 0) // Attack Card
            {
                GameObject Card = Instantiate(AttackCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                AttackCard attackCard = Card.GetComponent<AttackCard>();
                attackCard.Name_Of_Card = "Attack_Card_" + i.ToString();
                Card.name = attackCard.Name_Of_Card;

                attackCard.Cost_of_Card = costs_Of_Card;

                attackCard.Card_Portrait = AttackCardPortrait[Random.Range(0, AttackCardPortrait.Count)];
                Card.GetComponent<SpriteRenderer>().sprite = attackCard.Card_Portrait;

                attackCard.Card_Description = "Attack Card Description";

                attackCard.Damage = Random.Range(1, 6);

                attackCard.condition = Conditions.none;
            }


            else if (cardType == 1) // Defence Card
            {
                GameObject Card = Instantiate(DefenceCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                DefenceCard defenceCard = Card.GetComponent<DefenceCard>();
                defenceCard.Name_Of_Card = "Defence_Card_" + i.ToString();
                Card.name = defenceCard.Name_Of_Card;

                defenceCard.Cost_of_Card = costs_Of_Card;

                defenceCard.Card_Portrait = DefenceCardPortrait[Random.Range(0, DefenceCardPortrait.Count)];
                Card.GetComponent<SpriteRenderer>().sprite = defenceCard.Card_Portrait;

                defenceCard.Card_Description = "Defence Card Description";

                defenceCard.Defence_Value = Random.Range(1, 4);

                defenceCard.condition = Conditions.none;
            }


            else if (cardType == 2) // Special Card
            {
                GameObject Card = Instantiate(SpecialCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                SpecialCard specialCard = Card.GetComponent<SpecialCard>();
                specialCard.Name_Of_Card = "Special_Card_" + i.ToString();
                Card.name = specialCard.Name_Of_Card;

                specialCard.Cost_of_Card = costs_Of_Card;

                specialCard.Card_Portrait = SpecialCardPortrait[Random.Range(0, SpecialCardPortrait.Count)];
                Card.GetComponent<SpriteRenderer>().sprite = specialCard.Card_Portrait;

                specialCard.Card_Description = "Special Card Description";

                specialCard.condition = Conditions.No_Attacks;
            }
        }
    }
}