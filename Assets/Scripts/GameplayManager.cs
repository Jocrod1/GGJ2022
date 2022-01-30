using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public Animator InitialMenúAnimator;
    public Animator EnemySpawnerAnimator;
    public Animator LivesAnimator;


    public bool InGame = false;
    public void StartGame()
    {
        InitialMenúAnimator.SetBool("InGame", true);
        EnemySpawnerAnimator.SetBool("InGame", true);
        LivesAnimator.SetBool("InGame", true);
        InGame = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && InGame)
        {
            ResetScene();
        }
        
    }
}
