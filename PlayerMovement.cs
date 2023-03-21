using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float jumpHeight = 7f, moveSpeed, fallDeduction;
    public bool isGrounded;
    [SerializeField] private TMP_Text pearlCount, gameSpeed;
    public Transform movePoint;
    public AudioSource collect;
    
    private Rigidbody rb;
    [SerializeField] private GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movePoint.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed.text = GameData.gameInfo.gameSpeed.ToString();

        if (transform.position.y <= 0.55f)
        {
            transform.position = Vector3.Slerp(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (movePoint.position.x < 1 && Input.GetKeyDown(KeyCode.D))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") + 0.5f, 0f, 0f);
                }
                if (movePoint.position.x > -1 && Input.GetKeyDown(KeyCode.A))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") - 0.5f, 0f, 0f);
                }
            } 

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallDeduction * Time.deltaTime;

        }

    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Osui esteeseen!");
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Pearl"))
        {
            collect.Play();
            Destroy(other.gameObject);
            GameData.gameInfo.pearls++;
            pearlCount.text = GameData.gameInfo.pearls.ToString("#,###");
            GameData.gameInfo.gameSpeed = GameData.gameInfo.gameSpeed + 0.008f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}


