using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Controller
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class Button : MonoBehaviour
    {
        [SerializeField]
        public ButtonID button;

        public void OnClick()
        {
            GameManager.instance.buttonClicked(new ButtonPressEventArgs(
                button,
                0));
        }
    }
}
