using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex05 : MonoBehaviour
{
    private com comScript;
    private user userScript;

    private bool isInsideBox = false;
    private bool BoxCenter = false;
    
    private float moveSpeed = 5f;

    private void Start()
    {
        comScript = FindObjectOfType<com>();
        userScript = FindObjectOfType<user>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = true;
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            isInsideBox = false;
        }
        else if (collision.CompareTag("Center"))
        {
            BoxCenter = false;
        }
    }

    private void Update()
    {
        Collider2D itemCollider = GetComponent<Collider2D>();
        Collider2D boxCollider = GameObject.FindGameObjectWithTag("Box").GetComponent<Collider2D>();
        
        if (BoxCenter)
        {
            // Object is inside the box, stop moving
            // Add any additional code you need for when the object is inside the box
        }
        else
        {
            // Object is not inside the box, move from left to right at a constant speed
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        if (isInsideBox && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.red)
                {
                    comScript.Attack(25);
                }

                Destroy(gameObject);
            }
            else
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.blue)
                {
                    userScript.DefenseFail(10);
                }

                Destroy(gameObject);
            }
        }
        else if (isInsideBox && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (boxCollider.bounds.Contains(itemCollider.bounds.min) && boxCollider.bounds.Contains(itemCollider.bounds.max))
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.red)
                {
                    userScript.DefenseFail(10);
                }
                else if (renderer.material.color == Color.blue)
                {
                    userScript.DefenseFail(10);
                }

                Destroy(gameObject);
            }
            else
            {
                Renderer renderer = GetComponent<Renderer>();

                if (renderer.material.color == Color.blue)
                {
                    userScript.DefenseFail(10);
                }
                else if (renderer.material.color == Color.red)
                {
                    userScript.DefenseFail(10);
                }

                Destroy(gameObject);
            }
        }
    }
}
