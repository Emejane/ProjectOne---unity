using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed = 30f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
        transform.Rotate(-moveY, 0f, moveX, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager.Instance.SetLastPosition(transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision avec " + collision.gameObject.name);
    }
}



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject ballPrefab;
    private Vector3 lastCheckpointPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLastPosition(Vector3 position)
    {
        lastCheckpointPosition = position;
    }

    public void Respawn()
    {
        if (ballPrefab != null)
        {
            Instantiate(ballPrefab, lastCheckpointPosition, Quaternion.identity);
        }
    }
}
