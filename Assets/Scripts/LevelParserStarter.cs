using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting");
        RefreshParse();
    }


    private void FileParser()
    {
        //Debug.Log("Inside File Parser");
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            //Debug.Log("Outside of While Loop");
            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                //Debug.Log(line);
                foreach (var letter in letters)
                {
                    Vector3 position = new Vector3(column, -row, 0);
                    SpawnPrefab(letter, position);
                    column++;
                }
                row++;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        Debug.Log("Inside Spawning Prefab");
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': Debug.Log("Spawn Brick"); ToSpawn = Brick; break;
            case '?': Debug.Log("Spawn QuestionBox"); ToSpawn = QuestionBox; break;
            case 'x': Debug.Log("Spawn Rock"); ToSpawn = Rock; break;
            case 's': Debug.Log("Spawn Stone"); ToSpawn = Stone; break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        //Debug.Log("Parse Starting Up");
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
