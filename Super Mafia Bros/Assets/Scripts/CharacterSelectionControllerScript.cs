using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionControllerScript : MonoBehaviour
{

    public void ChooseCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        print("The Player Index that is selected is " + characterIndex);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Prototype_0");
    }

}
