using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceStorer : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    public GameObject storedPiece = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject StorePiece(TetrisBlock pieceToStore)
    {
        GameObject pieceToReturn = storedPiece;

        foreach (GameObject tetrimino in Tetrominoes)
        {
            if (pieceToStore.gameObject.tag == tetrimino.gameObject.tag)
            {
                storedPiece = tetrimino;
            }
        }

        Instantiate(storedPiece, transform.position, Quaternion.identity);
        return pieceToReturn;
    }
}
