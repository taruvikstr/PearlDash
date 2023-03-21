using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3[] positions;
    private int index;
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * GameData.gameInfo.gameSpeed * 10);

        if (transform.position.z < -10)
        {
            index = Random.Range(0, 3);
            transform.position = (positions[index]);
        }
    }

}
