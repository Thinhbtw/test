
using UnityEngine;
using System.Runtime.Serialization;

//Player Data Holder
[System.Serializable] public class PlayerData
{
    public int coin = 0;
}

public static class GameData
{
    static PlayerData playerData = new PlayerData();

    static GameData()
    {
        LoadPlayerData();
    }

        

    //Player Data Method
    
    public static int GetCoin()
    {
        return playerData.coin;
    }

    public static void AddCoin(int amount)
    {
        playerData.coin += amount;
        SavePlayerData();
    }

    public static bool CanSpendCoin(int amount)
    {
        return (playerData.coin >= amount);
    }

    public static void SpendCoin(int amount)
    {
        playerData.coin -= amount;
        SavePlayerData();
    }

    static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData>("player-data.txt");
        UnityEngine.Debug.Log("<color=green>[PlayerData] Loaded </color>");
            
    }

    static void SavePlayerData()
    {
        BinarySerializer.Save(playerData,"player-data.txt");
        UnityEngine.Debug.Log("<color=magenta>[PlayerData] Saved </color>");

    }

}
