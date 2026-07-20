public class DefenceCard : CardClass
{
    public int Defence_Value;
    public void Defence(int Def, int Cost, CardClass.Conditions con)
    {
        Defence_Value = Def;
        Cost_of_Card = Cost;
        condition = con;
    }
}