using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    public string playerName = "DefaultPlayer";
    public string bestPlayer = "X";
    public int bestScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        string path = Application.persistentDataPath + "/save.txt";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(playerName);
        writer.WriteLine(bestPlayer);
        writer.WriteLine(bestScore);
        writer.Close();
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/save.txt";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            playerName = reader.ReadLine();
            bestPlayer = reader.ReadLine();
            bestScore = int.Parse(reader.ReadLine());
        }
    }
}