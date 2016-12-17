using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    [SerializeField]
    private GameObject tile;

    public static GameManager instance
    {
        get { return _instance; }
        private set { _instance = value; }
    }


    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            generateMap();
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void mapTileClicked(Tile tile)
    {
        //TODO
        //This will probably be where most of the game logic will occur.
    }

    #region Button Clicks
    public void infoOptionClicked()
    {
        //TODO
    }

    public void selectOptionClicked()
    {
        //TODO
    }

    public void moveOptionClicked()
    {
        //TODO
    }

    public void attackOptionClicked()
    {
        //TODO
    }
    #endregion

    private void generateMap()
    {
        float xOffset = 10;
        float zOffset = 10;
        float xStart = 0;
        float zStart = 0;

        int x = 10;
        int y = 10;

        GameObject[] currentRow = new GameObject[y];
        GameObject[] lastRow = null;

        for(int i = 0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                GameObject tileInstance = Instantiate(tile);
                tileInstance.transform.position = new Vector3(xStart + xOffset * i, 0, zStart + zOffset * j);
                currentRow[j] = tileInstance;
                if (j - 1 > 0)
                {
                    tileInstance.GetComponent<Tile>().addNeighbor(currentRow[j - 1].GetComponent<Tile>());
                    currentRow[j - 1].GetComponent<Tile>().addNeighbor(tileInstance.GetComponent<Tile>());
                }
            }
            if (lastRow != null)
            {
                for(int j = 0; j < y; j++)
                {
                    lastRow[j].GetComponent<Tile>().addNeighbor(currentRow[j].GetComponent<Tile>());
                    currentRow[j].GetComponent<Tile>().addNeighbor(lastRow[j].GetComponent<Tile>());
                }
            }
            lastRow = currentRow;
            currentRow = new GameObject[y];
        }


    }
}
