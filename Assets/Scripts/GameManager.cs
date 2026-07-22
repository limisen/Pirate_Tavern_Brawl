using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static CardClass;

public class GameManager : MonoBehaviour
{
    GameLoop gameLoop;
    GameLoop Encounter_Loop;
    CameraSwitch cameraSwitch;

    [SerializeField] public GameObject ParentObject;

    [SerializeField] GameObject AttackCardPrefab;
    [SerializeField] GameObject DefenceCardPrefab;
    [SerializeField] GameObject SpecialCardPrefab;

    public int coins_Available = 50;
    public int costs_Of_Card = 3;
    public int player_HP = 30;
    public int opponent_HP = 30;

    public List<CardInteract> chosen_Cards = new();

    private void Start()
    {
        cameraSwitch = FindAnyObjectByType<CameraSwitch>();
        gameLoop = GetComponent<GameLoop>();

        // start of Encounter
        coins_Available = 50;
        costs_Of_Card = 3;
        player_HP = 30;
        opponent_HP = 30;

        // List of positons on the card list for where the cards will be instantiated
        var positionsOnListOfCards = new Dictionary<int, Vector3>
        {
            [1] = new Vector3(0.56f, 0.47f, 0),
            [2] = new Vector3(2.7f, 0.47f, 0),
            [3] = new Vector3(4.82f, 0.47f, 0),
            [4] = new Vector3(0.6f, -2.5f, 0),
            [5] = new Vector3(2.67f, -2.57f, 0),
            [6] = new Vector3(4.77f, -2.52f, 0),
            [7] = new Vector3(0.6f, -5.44f, 0),
            [8] = new Vector3(2.7f, -5.48f, 0),
        };

        // Create the list of cards
        for (int i = 1; i < 9; i++)
        {
            if (i <= 3)
            {
                GameObject Card = Instantiate(AttackCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                AttackCard attackCard = Card.GetComponent<AttackCard>();
                attackCard.Name_Of_Card = "Attack_Card_" + i.ToString();
                Card.name = attackCard.Name_Of_Card;

                attackCard.Cost_of_Card = costs_Of_Card;

                //attackCard.Card_Portrait = Sprite new sprite;

                attackCard.Card_Description = "blabla bla";

                attackCard.Damage = Random.Range(1, 4);

                attackCard.condition = Conditions.none;
            }
            else if (i > 3 && i <= 6)
            {
                GameObject Card = Instantiate(DefenceCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                DefenceCard defenceCard = Card.GetComponent<DefenceCard>();
                defenceCard.Name_Of_Card = "Defence_Card_" + i.ToString();
                Card.name = defenceCard.Name_Of_Card;

                defenceCard.Cost_of_Card = costs_Of_Card;

                defenceCard.Card_Description = "Bla Bla Bla";

                defenceCard.Defence_Value = Random.Range(1, 4);

                defenceCard.condition = Conditions.none;
            }
            else if (i > 6 && i <= 9)
            {
                GameObject Card = Instantiate(SpecialCardPrefab, ParentObject.transform);
                Card.transform.localPosition = positionsOnListOfCards[i];

                SpecialCard specialCard = Card.GetComponent<SpecialCard>();
                specialCard.Name_Of_Card = "Special_Card_" + i.ToString();
                Card.name = specialCard.Name_Of_Card;

                specialCard.Cost_of_Card = costs_Of_Card;

                specialCard.Card_Description = "Bla Bla Bla";

                specialCard.condition = Conditions.No_Attacks;
            }
        }
        // cards are selected for play
        cameraSwitch.SwitchToCamera("TableView");

        gameLoop.GameLoop_Method();

        //cameraSwitch.SwitchToCamera("BarView");

    }
}
