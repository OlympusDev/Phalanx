using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

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
}
