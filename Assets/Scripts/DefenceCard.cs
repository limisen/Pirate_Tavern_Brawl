public class DefenceCard : CardClass
{
    public int minDefence_Value;
    public int maxDefence_Value;
    public void Defence(int minDef, int maxDef, int Cost, CardClass.Conditions con)
    {
        minDefence_Value = minDef;
        maxDefence_Value = maxDef;
        Cost_of_Card = Cost;
        condition = con;
    }
}