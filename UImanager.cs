using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject gameOverPanel, instantiator;
    public float cooldown, timer;
    public bool skillReady;
    public Image counter;
    private bool paused;
    // Start is called before the first frame update
    void Awake()
    {
        skillReady = false;
        GameData.gameInfo.gameSpeed = 0f;
        instantiator.GetComponent<Instantiate>().StopCoroutine("SpawnerCoroutine");
        gameOverPanel.SetActive(false);
        Invoke("PlayAgain", 3f);

    }

    private void Update()
    {
        if(GameData.gameInfo.gameSpeed > 0.001f)
        {
            if (timer < cooldown && skillReady == false)
            {
                timer += Time.deltaTime;
            }
            else
            {
                
                skillReady = true;
            }

            counter.fillAmount = timer / cooldown;
        }

        if(GameData.gameInfo.pearls > 100)
        {
            cooldown = 10f;
        }
        else if(GameData.gameInfo.pearls > 70)
        {
            cooldown = 15f;
        }
        else if(GameData.gameInfo.pearls > 40)
        {
            cooldown = 20f;
        }


        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
            }
        }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
    public void Reload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EndlessRunner");
    }

    private void PlayAgain()
    {
        GameData.gameInfo.gameSpeed = 0.2f;
        instantiator.GetComponent<Instantiate>().StartCoroutine("SpawnerCoroutine");
    }

    public void SlowDown()
    {
        Debug.Log("pressing!");
        if(skillReady)
        {
            Debug.Log("Slow down skill activated!");
            StartCoroutine(SlowTime());
            timer = 0;
            skillReady = false;
        }
        
    }

    IEnumerator SlowTime()
    {
        GameData.gameInfo.gameSpeed = GameData.gameInfo.gameSpeed / 3f;
        yield return new WaitForSecondsRealtime(3f);
        GameData.gameInfo.gameSpeed = GameData.gameInfo.gameSpeed * 3f;
    }

}
