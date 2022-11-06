using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text amountText;
    public GameObject PlayerPrefab;

    public AudioClip pickupSound;

    public int amount;

    private void OnEnable()
    {
        amount = Random.Range(1, 6);
        amountText.text = amount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);

            for (int i = 0; i < amount; i++)
            {
                int index = collision.transform.childCount;
                GameObject newPlayer = Instantiate(PlayerPrefab, collision.transform);
                newPlayer.transform.localPosition = new Vector3(0, -index, 0);

                FollowTarget followTarget = newPlayer.GetComponent<FollowTarget>();
                if (followTarget != null)
                {
                    followTarget.target = collision.transform.GetChild(index - 1);
                }
            }

           Player player = collision.GetComponent<Player>();
            if(player != null)
            {
                player.SetText(player.transform.childCount);
            }

            
        }

        gameObject.SetActive(false);
    }
}
