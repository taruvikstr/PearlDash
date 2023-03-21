using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingGround : MonoBehaviour
{
    public Vector2 uvAnimVector = new Vector2(0.0f, 1.0f);
    Vector2 uvOffset = Vector2.zero;
    
    void Update()
    {
        uvOffset += (uvAnimVector * Time.deltaTime * GameData.gameInfo.gameSpeed);
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", uvOffset);
    }

}
