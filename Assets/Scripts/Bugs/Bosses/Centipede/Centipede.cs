using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : MonoBehaviour
{
    public GameObject headPiece, bodyPiece, endPiece;
    private List<GameObject> centipedePieces = new List<GameObject>();
    private int spawnedPiecesCount = 1;

    private bool allLegsBroken = false;
    private int length = 8;
    private bool stop = false;
    private bool toldAllBody = false, allBodyCreated = false;

    private void Start()
    {
        CreateBody(1);
    }
    private void LateUpdate()
    {
        int counter = 0;
        for(int i = 0; i < centipedePieces.Count; i++)
        {
            if(centipedePieces[i].GetComponent<CentipedeBody>().GetBodyHurt())
            {
                counter++;
            }
        }
        for (int i = 0; i < centipedePieces.Count; i++)
        {
            Debug.Log(counter);
            Debug.Log(centipedePieces.Count);
            if(counter == centipedePieces.Count && !toldAllBody && allBodyCreated)
            {
                centipedePieces[i].GetComponent<CentipedeBody>().SetEntireBodyBroke(true, centipedePieces[0].gameObject.GetComponent<Rigidbody>().transform.position);
                // burrow - create particle effect of dirt being shoveled whilst moving all body to head position.
            }
            else
            {
                centipedePieces[i].GetComponent<CentipedeBody>().SetMoveSpeed(8);
            }
        }
        if (counter == centipedePieces.Count && !toldAllBody && allBodyCreated)
        {
            toldAllBody = true;
        }
    }
    private void CreateBody(int i)
    {
        if(!stop)
            switch(i)
            {
                case 0:
                    StartCoroutine(SpawnPart(endPiece));
                    stop = true;
                    allBodyCreated = true;
                    break;
                case 1:
                    centipedePieces.Add(Instantiate(headPiece, new Vector3(0f, 11, 0), Quaternion.identity));
                    centipedePieces[0].GetComponent<CentipedeBody>().SetHeadPiece(true);
                    StartCoroutine(SpawnPart(bodyPiece));
                    break;
                default:
                    StartCoroutine(SpawnPart(bodyPiece));
                    break;
            }

    }
    IEnumerator SpawnPart(GameObject part)
    {
        yield return new WaitForSeconds(0.1f);
        centipedePieces.Add(Instantiate(part, new Vector3(0, 11, 0), Quaternion.identity));
        spawnedPiecesCount++;
        if(spawnedPiecesCount <= length)
        {
            CreateBody(spawnedPiecesCount);
        }
        else if(spawnedPiecesCount >= length)
        {
            CreateBody(0);
        }
    }
}
