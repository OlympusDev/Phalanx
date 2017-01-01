using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public class MapManager : MonoBehaviour
    {
        private static MapManager _instance = null;

        public static MapManager instance
        {
            get
            {
                return _instance;
            }
        }

        [SerializeField]
        private GameObject[] tile;



        // Use this for initialization
        void Start()
        {
            generateMap();
        }

        // Update is called once per frame
        void Update()
        {

        }
        ICollection<Tile> calculateRange(Tile origin, MoveInfo moves)
        {
            //TODO
            return null;
        }

        private void generateMap()
        {
            float xOffset = 10;
            float zOffset = 10;
            float xStart = 0;
            float zStart = 0;

            int x = 10;
            int y = 10;

            int types = tile.Length;
            int count = 0;

            GameObject[] currentRow = new GameObject[y];
            GameObject[] lastRow = null;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    GameObject tileInstance = Instantiate(tile[count%types]);
                    count++;
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
                    for (int j = 0; j < y; j++)
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
}
