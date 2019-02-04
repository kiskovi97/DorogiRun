
public class PlayerData
{
    public static int topScore = 0;
    public static int actualGameScore = 0;
    public static int allCoin = 110;
    public static int actualCoin = 0;

    public static int shieldLevel = 0;
    public static int magnetLevel = 0;
    public static int reviveItemCount = 2;

    public static void ResetAll()
    {
        topScore = 0;
        actualGameScore = 0;
        allCoin = 100000;
        actualCoin = 0;

        shieldLevel = 0;
        magnetLevel = 0;
        reviveItemCount = 2;
    }
}
