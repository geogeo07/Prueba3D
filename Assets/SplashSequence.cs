using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
   public static int SceneNumber;
  
   void LoadSceneFunction()
   {
       if(SceneNumber==0)
       {
           StartCoroutine(ToSplashTwo());
       }
       if(SceneNumber==1)
       {
           StartCoroutine(ToMainMenu());
       }
   }

   
   IEnumerator ToSplashTwo()
   {
       yield return new WaitForSeconds(3);
       SceneNumber = 1;
       SceneManager.LoadScene("SplashScreen2", LoadSceneMode.Additive);
   }


   IEnumerator ToMainMenu()
   {
       yield return new WaitForSeconds(3);
       SceneNumber = 2;
       SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
   }
 
    // Update is called once per frame

}
