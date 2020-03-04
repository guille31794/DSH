using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private readonly float fallDelay = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(2);

        switch(gameObject.name)
        {
            case "LefTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                break;

            case "TopTile":
                TileManager.Instance.TopTiles.Push(gameObject);
                break;
            default:
                break;
        }

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.SetActive(false);
    }
}
