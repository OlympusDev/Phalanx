using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Tools
{
    [RequireComponent(typeof(UnityEngine.UI.Text))]
    public class Logger : MonoBehaviour
    {
        Controller.GameManager gameManager { get; set; }
        UnityEngine.UI.Text text
        {
            get;
            set;
        }
        // Use this for initialization
        void Start()
        {
            text = GetComponent<UnityEngine.UI.Text>();
            gameManager = Controller.GameManager.instance;
        }

        // Update is called once per frame
        void Update()
        {
            text.text = gameManager.debugInfo();
        }
    }
}
