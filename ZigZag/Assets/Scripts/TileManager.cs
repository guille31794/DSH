using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject[] tilePrefabs; 
    private static TileManager instance;
    private Stack<GameObject> leftTiles =
        new Stack<GameObject>(),
        topTiles = new Stack<GameObject>();

    public Stack<GameObject> TopTiles
    {
        get
        {
            return topTiles;
        }
    }

    public Stack<GameObject> LeftTiles
    {
        get
        {
            return leftTiles;
        }
    }

    public static TileManager Instance 
    {
        get
        {
            if(instance == null)
                instance = GameObject.FindObjectOfType<TileManager>();

            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateTiles(20);
        for(int i = 0; i < 10; ++i)
            SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTiles(int amount)
    {
        for(int i = 0; i < amount; ++i)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));
            topTiles.Peek().name = "TopTile";
            leftTiles.Peek().SetActive(false);
            topTiles.Peek().SetActive(false);
            leftTiles.Peek().name = "LeftTile";
        }
    }

    public void SpawnTile()
    {
        if(leftTiles.Count == 0 || topTiles.Count == 0)
        {
            CreateTiles(10);
        }

        int randomIndex = Random.Range(0, 2);

        if(randomIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else
        {
            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        int spawnPickUp = Random.Range(0,10);

        if(spawnPickUp == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
