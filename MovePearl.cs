using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePearl : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * GameData.gameInfo.gameSpeed * 10);

        if(transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }

}
