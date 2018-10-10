using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EscapeTheMagiskSkog {
	public class StartMenuController : MonoBehaviour {
        
        private GameObject menuCamera;
        private GameObject menuCanvas;

        public void Start () {
            menuCamera = GameObject.Find("MenuCamera");
            menuCanvas = GameObject.Find("MenuCanvas");
        }
        public void PlayGame () {
            menuCamera.SetActive(false);
            menuCanvas.SetActive(false);
        }

        public void QuitGame () {
            Application.Quit();
        }
    }
}