using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGrabber : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    public static GameObject tetriminoToPlay;
    public static GameObject nextTetrimino;

    public 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void GrabNextPiece()
    {
        nextTetrimino = FindObjectOfType<SpawnTetromino>().GrabTetrimino();
        tetriminoToPlay = Tetrominoes[0];
        foreach (GameObject tetrimino in Tetrominoes)
        {
            if(nextTetrimino.gameObject.tag == tetrimino.gameObject.tag)
            {
                tetriminoToPlay = tetrimino;
            }
        }

        Instantiate(tetriminoToPlay, transform.position, Quaternion.identity);
    }

    // NOTE: This needs to be fixed, not functional right now. Meant to grab and store stored pieces.
    public void StorePiece(TetrisBlock tetriminoToStore)
    {
        GameObject newTetrimino = FindObjectOfType<PieceStorer>().StorePiece(tetriminoToStore);
        Destroy(tetriminoToStore.gameObject);
        if (newTetrimino != null)
        {
            foreach (GameObject tetrimino in Tetrominoes)
            {
                if (newTetrimino.gameObject.tag == tetrimino.gameObject.tag)
                {
                    Instantiate(tetrimino, transform.position, Quaternion.identity);
                }
            }
        }
        else
        {
            GrabNextPiece();
        }
    }
}
