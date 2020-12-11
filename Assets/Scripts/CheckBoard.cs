using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CheckBoard : MonoBehaviour
{
    public static int[] good;
    public static int[] bad;

    public Transform grid;

    private Scene current_Scene;
    private string sceneName;

    private float score=0;

    private Toggle[] toggles;

    public Text scoreText;

    public void done()
    {
        score = 0;
        //set board
        current_Scene = SceneManager.GetActiveScene();
        sceneName = current_Scene.name;
        if (sceneName == "Dog")
        {
            good= new int[] { 3, 4, 5, 6, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 32, 34, 35, 37, 39, 40, 42, 44, 45, 47, 49, 50, 52, 53, 54, 55, 56, 57, 59, 62, 63, 64, 65, 66, 67, 72, 73, 76, 77, 83, 84, 85, 86, 94, 95 };
            bad= new int[] { 0, 1, 2, 7, 8, 9, 10, 19, 31, 33, 36, 38, 41, 43, 46, 48, 51, 58, 60, 61, 68, 69, 70, 71, 74, 75, 78, 79, 80, 81, 82, 87, 88, 89, 90, 91, 92, 93, 96, 97, 98, 99 };
        }
        else if (sceneName == "Fish")
        {
            good= new int[] { 3, 4, 10, 11, 14, 15, 16, 21, 25, 26, 31, 32, 34, 35, 36, 37, 42, 43, 44, 45, 46, 47, 48, 52, 53, 54, 55, 56, 58, 59, 61, 62, 63, 64, 65, 66, 67, 68, 69, 71, 72, 74, 75, 76, 77, 78, 80, 81, 85, 86, 94, 95 };
            bad= new int[] {0,1,2,5,6,7,8,9,12,13,17,18,19,20,22,23,24,27,28,29,30,33,38,39,40,41,49,50,51,57,60,70,73,79,82,83,84,87,88,89,90,91,92,93,96,97,98,99 };
        }
        else if (sceneName == "Teapot")
        {
            good= new int[] { 5, 13, 14, 15, 16, 17, 23, 24, 25, 26, 27, 30, 31, 33, 35, 36, 37, 38, 39, 41, 43, 44, 45, 46, 47, 49, 51, 53, 55, 56, 57, 59, 61, 62, 63, 65, 66, 67, 69, 71, 72, 73, 74, 75, 76, 77, 78, 79, 83, 84, 85, 86, 87, 93, 94, 95, 96, 97 };
            bad= new int[] { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 18, 19, 20, 21, 22, 28, 29, 32, 34, 40, 42, 48, 50, 52, 54, 58, 60, 64, 68, 70, 80, 81, 82, 88, 89, 90, 91, 92, 98, 99 };
        }
        toggles = grid.GetComponentsInChildren<Toggle>();
        score = 0;
        //find score
        for (int i=0; i<100; i++)
        {
           if (toggles[i].isOn && good.Contains(i)){
                score++;
            }
            if (toggles[i].isOn && bad.Contains(i))
            {
                score--;
            }
           

        }
        float finalScore = (score / good.Length)*100;

        //display score
        if (finalScore == 100)
        {
            scoreText.text = ("You Won!");
        }
        else if (finalScore < 0){
            scoreText.text = ("You Scored:\n0%");
        }
        else
        {
            scoreText.text = ("You Scored:\n" + Mathf.Round(finalScore) + "%");
        }
        
    }

   
}
