using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasKey : MonoBehaviour
{
    public bool hasKey = false;
    public bool canGetKey = false;
    public GameObject key;
    [SerializeField] private GameObject KeyUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Key>())
        {
            canGetKey = true;
            KeyUI.SetActive(true);
            Debug.Log("Player is allowed to get key!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canGetKey = false;
        KeyUI.SetActive(false);
        Debug.Log("Player is not allowed to get key!");
    }

    private void Update()
    {
        if (canGetKey && Input.GetKey(KeyCode.E))
        {
            hasKey = true;
            Debug.Log("Key is collected!");
            Destroy(key);
        }
    }

    /**
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KeyUI.SetActive(true);
            Debug.Log("PAKITA UI");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KeyUI.SetActive(false);
            Debug.Log("NO UI");
        }
    }
    **/
}
