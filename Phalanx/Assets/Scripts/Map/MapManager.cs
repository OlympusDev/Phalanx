using System.Collections.Generic;
using Olympus.Phalanx.Controller;
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
        public GameManager gameManager {
            get;
            private set;
        }

        [SerializeField]
        private GameObject[][] tile;

        private int[][] mapDef = new int[][]
        {
            new int []{1,1,1,1,1,1,2,2,2,1,1,1,1 },
            new int []{1,1,1,1,1,1,1,0,1,1,1,1,1 },
            new int []{1,1,1,1,3,3,3,0,1,1,3,1,1 },
            new int []{1,1,1,1,0,0,0,0,0,1,3,1,1 },
            new int []{1,1,3,1,2,2,2,2,2,1,3,1,1 },
            new int []{1,1,3,1,0,0,0,0,0,1,1,1,1 },
            new int []{1,1,3,1,1,0,3,3,3,1,1,1,1 },
            new int []{1,1,1,1,1,0,1,1,1,1,1,1,1 },
            new int []{1,1,1,1,2,2,2,1,1,1,1,1,1 }
        };

        private Dictionary<Point, Tile> map;

        public event TileClickEvent tileClickEvent;

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

        void Start()
        {
            gameManager = GameManager.instance;
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

        IList<Tile> calculatePath(Tile origin, MoveInfo moves)
        {
            //TODO
            return null;
        }

        private void LoadTiles()
        {
            tile = new GameObject[4][];
            tile[0] = Resources.LoadAll<GameObject>("Map/Water");
            tile[1] = Resources.LoadAll<GameObject>("Map/Dirt");
            tile[2] = Resources.LoadAll<GameObject>("Map/Bridge");
            tile[3] = Resources.LoadAll<GameObject>("Map/Obstacle");
            Debug.Log(tile[0].Length + " " +
                tile[1].Length + " " +
                tile[2].Length + " " +
                tile[3].Length + " ");
        }

        private void generateMap()
        {
            #region placeholder Code
            float xOffset = 10;
            float zOffset = 10;
            float xStart = 0;
            float zStart = 0;

            int x = 10;
            int y = 10;

            int types = tile.Length;
            if(types == 0)
            {
                return;
            }

            Tile[] currentRow = null;
            Tile[] lastRow = null;
            Tile current = null;

            for (int i = 0; i < mapDef.Length; i++)
            {
                currentRow = new Tile[mapDef[i].Length];
                for (int j = 0; j < mapDef[i].Length; j++)
                {
                    current = makeTile(mapDef[i][j]);
                    current.transform.parent.position = new Vector3(xStart + xOffset * i, 0, zStart + zOffset * j);

                    currentRow[j] = current;
                    current.position = new Point(i, j);
                    current.tileClicked += (Tile tile,TileClickEventArgs eventArgs)=>
                    {
                        tileClickEvent(tile, eventArgs);
                    };
                    map.Add(current.position, current);
                    if (j - 1 > 0)
                    {
                        current.addNeighbor(currentRow[j - 1]);
                        currentRow[j - 1].addNeighbor(current);
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
            #endregion
        }

        private Tile makeTile(int type)
        {
            int variant = Random.Range(0, tile[type].Length);
            GameObject tileInstance = Instantiate(tile[type][variant]);
            Tile current = null;
            current = tileInstance.GetComponentInChildren<Tile>();

            return current;
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
