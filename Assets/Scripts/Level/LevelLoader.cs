/*
 Idea and some Code from quill18 Youtube Tutorial
 https://www.youtube.com/watch?v=5RzziXSwSsg
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ColorToPrefab
{
    public Color32 color;
    public GameObject prefab;
}

public class LevelLoader : MonoBehaviour
{

    private string levelFileName;
    public string[] levelNames;

    //public Texture2D LevelMap;

    public ColorToPrefab[] colorToPrefab;

    // Use this for initialization
    void Start()
    {
        LoadMap();
    }

    void EmptyMap()
    {
        while (transform.childCount > 0)
        {
            Transform c = transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }
    }

    void LoadMap()
    {
        EmptyMap();
        ChooseLevel(0);

        string filePath = Application.dataPath + "/StreamingAssets/Levels/" + levelFileName;

        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
        Texture2D LevelMap = new Texture2D(2, 2);
        LevelMap.LoadImage(bytes);

        Color32[] allPixels = LevelMap.GetPixels32();
        int width = LevelMap.width;
        int height = LevelMap.height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                SpawnTileAt(allPixels[(y * width) + x], x, y);
            }
        }
    }



    void SpawnTileAt(Color32 c, int x, int y)
    {
        if (c.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab ctp in colorToPrefab)
        {
            if (c.Equals(ctp.color))
            {
                GameObject go = Instantiate(ctp.prefab, new Vector3(x, y, 0), Quaternion.identity);
                go.transform.SetParent(this.transform);
                return;
            }
        }

        Debug.Log("No colorToPrefab found for: " + c.ToString());
    }

    void ChooseLevel(int i)
    {
        //Do something here to choose the Level from outside of this Class

        levelFileName = levelNames[i];
    }
}
