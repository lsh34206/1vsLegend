using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float currentcooltime = 0.5f;

    private float cooltime;
    private float timer;

    void Start()
    {
        cooltime = currentcooltime;
        timer = cooltime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject randomObject = objectsToSpawn[randomIndex];

            GameObject spawnedObject = Instantiate(randomObject, transform.position, Quaternion.identity);

            Renderer renderer = spawnedObject.GetComponent<Renderer>();

            Color randomColor = Random.Range(0, 2) == 0 ? Color.red : Color.blue;
            renderer.material.color = randomColor;

            timer = cooltime;
        }

        cooltime = Mathf.Max(cooltime, 0f);
    }
}

