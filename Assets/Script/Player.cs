using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private float mouseDistance;
    private Rigidbody2D rb;

    public float speed = 6;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xPos = worldPoint.x;

        mouseDistance = Mathf.Clamp(xPos - transform.position.x, -1, 1);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mouseDistance * speed,LevelController.instance.gameSpeed);
    }
}
