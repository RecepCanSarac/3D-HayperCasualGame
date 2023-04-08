using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    CurrentDirection cr;
    public bool isPlayerDead = false;
    private GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.left;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerDead)
        {
            RayCastDetector();
            //Telefonda Oynayabilmek için gereken kod
            //(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeDirection();
                StopPlayer();
            }
        }
        else
            return;
    }

    private void RayCastDetector()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down,out hit))
        {
            MovePlayer();
        }
        else
        {
            StopPlayer();
            isPlayerDead = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd();
        }
    }
    private enum CurrentDirection
    {
        right,left
    }
    private void ChangeDirection()
    {
        MovePlayer();
        if (cr == CurrentDirection.right)
        {
            cr = CurrentDirection.left;
        }
        else if (cr == CurrentDirection.left)
        {
            cr = CurrentDirection.right;
        }
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime,ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void StopPlayer()
    {
        rb.velocity = Vector3.zero;
    }
}
