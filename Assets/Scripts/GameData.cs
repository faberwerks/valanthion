using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    private static ArrayList itemList = new ArrayList();

    private string[] splitResult = new string[5];

    void Awake()
    {
        readTextFile("Assets/Game Data/items.dat");
    }

    // a method to read text file
    public void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string database = inp_stm.ReadLine();
            splitResult = database.Split('|');
            itemList.Add(splitResult);
        }

        inp_stm.Close();
    }

    /////// PROPERTIES ///////
    public static ArrayList ItemList
    {
        get
        {
            return itemList;
        }
    }
}
