using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public class MapManager : MonoBehaviour
    {
        public static MapManager instance
        {
            get;
            private set;
        }

        [SerializeField]
        private GameObject[] tile;

        private Dictionary<Point, Tile> map;

        public Tile this[Point position]
        {
            get
            {
                if (map.ContainsKey(position))
                {
                    return map[position];
                }
                return null;
            }
        }

        // Use this for initialization
        void Awake()
        {
            if (instance != null)
                Destroy(this);
            instance = this;
            map = new Dictionary<Point, Tile>(100);
            LoadTiles();
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

        private void LoadTiles()
        {
            tile = Resources.LoadAll<GameObject>("Map");
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
            if(types == 0)
            {
                return;
            }

            Tile[] currentRow = new Tile[y];
            Tile[] lastRow = null;
            Tile current = null;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    GameObject tileInstance = Instantiate(tile[count % types]);
                    count++;
                    tileInstance.transform.position = new Vector3(xStart + xOffset * i, 0, zStart + zOffset * j);

                    current = tileInstance.GetComponentInChildren<Tile>();
                    currentRow[j] = current;
                    current.position = new Point(i, j);
                    map.Add(current.position, current);
                    if (j - 1 > 0)
                    {
                        tileInstance.GetComponentInChildren<Tile>().addNeighbor(currentRow[j - 1]);
                        currentRow[j - 1].addNeighbor(tileInstance.GetComponentInChildren<Tile>());
                    }

                }
                if (lastRow != null)
                {
                    for (int j = 0; j < y; j++)
                    {
                        lastRow[j].addNeighbor(currentRow[j]);
                        currentRow[j].addNeighbor(lastRow[j]);
                    }
                }
                lastRow = currentRow;
                currentRow = new Tile[y];
            }


        }
    }

    public struct Point
    {
        public int x;
        public int y;

        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return "X: " + x + " Y: " + y;
        }
    }
}
