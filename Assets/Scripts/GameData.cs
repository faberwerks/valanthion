using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    string[] splitResult = new string[5];
    public ArrayList itemList = new ArrayList();

    private bool hasRead = false;

    // Use this for initialization
    void Awake()
    {
        readTextFile("Assets/Game Data/items.dat");
    }

    private void Update()
    {
        if (hasRead)
        {
            foreach (string[] currString in itemList)
            {
                Debug.Log(currString[0]);
            }
        }
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

        hasRead = true;
    }
}
