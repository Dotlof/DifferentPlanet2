using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Chunk : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite blue;
    public Sprite red;
    public Sprite green;
    public Sprite yellow;

    int setbiome = 0;
    int probBlue;
    int probRed;
    int probGreen;
    int probYellow;

    int rangeBlue;
    int rangeRed;
    int rangeGreen;
    int rangeYellow;

    GameObject[] chunks;

    void biomeSetter()
    {
        chunks = GameObject.FindGameObjectsWithTag("Chunk");

        rangeBlue = 10;
        rangeRed = 10;
        rangeGreen = 10;
        rangeYellow = 10;

        if (chunks.Length > 0)
        {
            foreach (GameObject chunk in chunks)
            {
                if (Vector2.Distance(this.transform.position, chunk.transform.position) < 20000)
                {
                    switch (chunk.GetComponent<scr_Chunk>().setbiome)
                    {
                        case 1:
                            rangeBlue = rangeBlue + 2;
                            break;
                        case 2:
                            rangeRed = rangeRed + 2;
                            break;
                        case 3:
                            rangeGreen = rangeGreen + 2;
                            break;
                        case 4:
                            rangeYellow = rangeYellow + 2;
                            break;
                    }
                }
            }
        }

        probBlue = Random.Range(0, rangeBlue);
        probRed = Random.Range(0, rangeRed);
        probGreen = Random.Range(0, rangeGreen);
        probYellow = Random.Range(0, rangeYellow);

        Debug.Log(probBlue);

        if (probBlue > probRed && probBlue > probGreen && probBlue > probYellow)
        {
            setbiome = 1;
            spriteRenderer.sprite = blue;
        }
        if (probRed > probBlue && probRed > probGreen && probRed > probYellow)
        {
            setbiome = 2;
            spriteRenderer.sprite = red;
        }
        if (probGreen > probRed && probGreen > probBlue && probGreen > probYellow)
        {
            setbiome = 3;
            spriteRenderer.sprite = green;
        }
        if (probYellow > probRed && probYellow > probGreen && probYellow > probBlue)
        {
            setbiome = 4;
            spriteRenderer.sprite = yellow;
        }

        if (setbiome == 0) biomeSetter();
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        biomeSetter();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
