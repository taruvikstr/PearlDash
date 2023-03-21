using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject collectible;
    public float[] spots;
    public int index;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            index = Random.Range(0, 2);
            Instantiate(collectible,
                new Vector3(
                    spots[index],
                    -1f,
                    GenerateEvenNumber(6, 80)
                    ),
                Quaternion.identity);
        }

        StartCoroutine(SpawnerCoroutine());
    }

    IEnumerator SpawnerCoroutine()
    {
        while (enabled)
        {
            index = Random.Range(0, 2);
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            Instantiate(collectible,
                new Vector3(
                    spots[index],
                    transform.position.y,
                    GenerateEvenNumber(80, 100)
                    ),
                Quaternion.identity);
        }
    }

    public int GenerateEvenNumber(int min, int max)
    {
        int evenNumber = Random.Range(min, max);
        if (evenNumber % 2 != 0)
        {
            evenNumber++;
            
        }
        return evenNumber;
    }

}
