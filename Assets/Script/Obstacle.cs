using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public Text amountText;

    public AudioClip impactSound;

    private int amount;

    private Material ñhange;

    private Player player;
    private float nextTime;

    private Color initialColor;

    private void Awake()
    {
        ñhange = GetComponent<MeshRenderer>().material;
       
    }


    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(player != null && nextTime < Time.time)
        {
            PlayerDamage();
        }
    }
    public void SetAmount()
    {
        gameObject.SetActive(true);
        amount = Random.Range(0, LevelController.instance.obstaclesAmount);
        if (amount <= 0)
        {
            gameObject.SetActive(false);
        }
        SetAmountText();
        SetColor();
        
    }

    public void SetAmountText()
    {
        amountText.text = amount.ToString();
    }

    public void SetColor()
    {
        int playerLives = FindObjectOfType<Player>().transform.childCount;
        Color newColor;

        if(amount > playerLives)
        {
            newColor = LevelController.instance.hardColor;
        }
        else if (amount > playerLives / 2)
        {
            newColor = LevelController.instance.mediumColor;
        }
        else
        {
            newColor = LevelController.instance.easyColor;
        }
        ñhange.color = newColor;
        initialColor = newColor;

    }

    void PlayerDamage()
    {
        if (LevelController.instance.gameOver)
            return;

        AudioSource.PlayClipAtPoint(impactSound, Camera.main.transform.position);
        nextTime = Time.time + LevelController.instance.damageTime;
        player.TakeDamage();
        amount--;
        SetAmountText();
        if(amount <= 0)
        {
            gameObject.SetActive(false);
            player = null;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(DamageColor());
        }
    }

    IEnumerator DamageColor()
    {
        float timer = 0;
        float t = 0;

        ñhange.color = initialColor;

        while (timer < LevelController.instance.damageTime)
        {
            ñhange.color = Color.Lerp(initialColor, Color.white, t);
            timer += Time.deltaTime;
            t += Time.deltaTime / LevelController.instance.damageTime;
            yield return null;
        }

        ñhange.color = initialColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player collisionPlayer = collision.gameObject.GetComponent<Player>();
        if(collisionPlayer != null)
        {
            player = collisionPlayer;
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player collisionPlayer = collision.gameObject.GetComponent<Player>();
        if (collisionPlayer != null)
        {
            player = null;
        }
    }
}
