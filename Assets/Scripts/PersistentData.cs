using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;

    public string playerName;
    public string bestPlayer;
    public int bestScore;

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
            //File.Delete(path);
            StreamReader reader = new StreamReader(path);
            playerName = reader.ReadLine();
            bestPlayer = reader.ReadLine();
            bestScore = int.Parse(reader.ReadLine());
        }
    }
}