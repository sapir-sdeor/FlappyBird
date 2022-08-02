using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openning : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Scenes/Open");
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    
    public void Instruction()
    {
        SceneManager.LoadScene("Scenes/Instruction");
    }
    
    
}
