using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 
 
public class menuScript : MonoBehaviour 
{
    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
 
    void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button> ();
        exitText = exitText.GetComponent<Button> ();
        quitMenu.enabled = false;
 
    }
 
    public void ExitPress() {
        quitMenu.enabled = true; //enable the Quit menu when we click the Exit button
        startText.enabled = false; //then disable the Play and Exit buttons so they cannot be clicked
        exitText.enabled = false;
 
    }
 
    public void NoPress() {
        quitMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
        exitText.enabled = true;
 
    }
 
    public void StartLevel () {
        SceneManager.LoadScene (1); //this will load our first level from our build settings. "1" is the second scene in our game
    }
 
    public void ExitGame () {
    	Application.Quit(); 
    }
 
}