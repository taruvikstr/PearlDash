using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameData : MonoBehaviour
{

    public static GameData gameInfo;


    public int pearls;
    public float gameSpeed;

    
    
    // Start is called before the first frame update
    void Awake()
    {
        
        if (gameInfo == null)
        {
            DontDestroyOnLoad(gameObject);  //tätä objektia ei tuhota scenen vaihtojen välillä
            gameInfo = this;
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

}

[Serializable]

class GameInfo
{
    public int pearls;
    public float gameSpeed;
   
}
