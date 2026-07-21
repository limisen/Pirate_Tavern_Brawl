public class SpecialCard : CardClass
{
    public void Special(int Cost, CardClass.Conditions con)
    {
        Cost_of_Card = Cost;
        condition = con;
    }
}