using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData : MonoBehaviour
{
    private static ArrayList itemList = new ArrayList();

    string[] splitResult = new string[5];

    private bool hasRead = false;

    void Awake()
    {
        readTextFile("Assets/Game Data/items.dat");
    }

    private void Update()
    {
        // NOTE: What is this part for if there's no need to debug anymore?
        //if (hasRead)
        //{
        //    foreach (string[] currString in itemList)
        //    {
        //        Debug.Log(currString[0]);
        //        Debug.Log(currString[1]);
        //        Debug.Log(currString[2]);

        //    }
        //}
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

    /////// PROPERTIES ///////
    public static ArrayList ItemList
    {
        get
        {
            return itemList;
        }
    }
}
