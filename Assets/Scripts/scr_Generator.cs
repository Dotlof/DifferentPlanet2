using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Generator : MonoBehaviour
{
    public GameObject starship;
    public GameObject chunk;
    public int range;
    GameObject[] chunks;

    Vector3 starshipPos;
    Vector2[] chunkPos;
    float spawnMultiplierX;
    float spawnMultiplierY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        starshipPos = starship.transform.position;
        spawnMultiplierX = Mathf.Round(starshipPos.x / 8192);
        spawnMultiplierY = Mathf.Round(starshipPos.y / 8192);

        chunkPos = new Vector2[] {new Vector2(spawnMultiplierX * 8192, spawnMultiplierY * 8192), new Vector2((spawnMultiplierX + range) * 8192, spawnMultiplierY * 8192), new Vector2((spawnMultiplierX - range) * 8192, spawnMultiplierY * 8192), new Vector2(spawnMultiplierX * 8192, (spawnMultiplierY + range) * 8192), new Vector2(spawnMultiplierX * 8192, (spawnMultiplierY - range) * 8192), new Vector2((spawnMultiplierX + range) * 8192, (spawnMultiplierY + range) * 8192), new Vector2((spawnMultiplierX - range) * 8192, (spawnMultiplierY + range) * 8192), new Vector2((spawnMultiplierX + range) * 8192, (spawnMultiplierY - range) * 8192), new Vector2((spawnMultiplierX - range) * 8192, (spawnMultiplierY - range) * 8192), };

        foreach (Vector2 chunkPlace in chunkPos)
        {
            chunks = GameObject.FindGameObjectsWithTag("Chunk");

            bool activeChunk = false;

            foreach (GameObject chonk in chunks)
            {
                if (Vector2.Distance(chonk.transform.position, chunkPlace) < 1)
                {
                    activeChunk = true;
                }
            }

            if (!activeChunk)
            {
                Instantiate(chunk, new Vector3(chunkPlace.x,chunkPlace.y, 0), Quaternion.identity);
            }
        }

        Debug.Log("X: " + spawnMultiplierX + "  Y: " + spawnMultiplierY);

    }
}
