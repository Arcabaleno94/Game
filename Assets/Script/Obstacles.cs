using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Obstacle[] allObstacles;
    public GameObject[] barriers;

    public Vector2 positionRange;
    public GameObject obstaclesGroup;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Coroutine());
        player = FindObjectOfType<Player>().transform;
        SetObstacles();
    }
    void SetObstacles()
    {
        for (int i = 0; i < allObstacles.Length; i++)
        {
           allObstacles[i].SetAmount();
        }

        for (int i = 0; i < barriers.Length; i++)
        {
            bool randomBool = Random.value > 0.5f;
            barriers[i].SetActive(randomBool);
        }
    }

    void Reposition()
    {
        int obstaclesAmount = FindObjectsOfType<Obstacles>().Length;

        transform.position = new Vector2(0, player.position.y + (LevelController.instance.obstaclesDistance * (obstaclesAmount - 1)));

        obstaclesGroup.transform.localPosition = new Vector2(0, Random.Range(positionRange.x, positionRange.y));
    }

    void DecreaseDifficulty()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Reposition();

            SetObstacles();
        }
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(30f);

        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.GetComponent<BoxCollider2D>();
        col.enabled = false;
        yield break;

    } 

}
