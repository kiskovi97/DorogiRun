
public class PlayerData
{
    public static int topScore = 0;
    public static int actualGameScore = 0;
    public static int allCoin = 110;
    public static int actualCoin = 0;

    public static int shieldLevel = 0;
    public static int magnetLevel = 0;
    public static int reviveItemCount = 2;
    public static float volume;

    public static void SetFromData(Data data)
    {
        topScore = data.topScore;
        allCoin = data.allCoin;
        shieldLevel = data.shieldLevel;
        magnetLevel = data.magnetLevel;
        reviveItemCount = data.reviveItemCount;
        volume = data.volume;
    }

    public static Data GetData()
    {
        Data data = new Data
        {
            topScore = topScore,
            allCoin = allCoin,
            shieldLevel = shieldLevel,
            magnetLevel = magnetLevel,
            reviveItemCount = reviveItemCount,
            volume = volume
        };
        return data;
    }

    public static void ResetAll()
    {
        topScore = 0;
        actualGameScore = 0;
        allCoin = 100000;
        actualCoin = 0;

        shieldLevel = 0;
        magnetLevel = 0;
        reviveItemCount = 2;
        volume = 1f;
    }
}
