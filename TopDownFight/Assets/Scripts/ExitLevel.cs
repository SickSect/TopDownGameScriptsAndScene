using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : Collidable
{
    public string[] sceneNames;

   protected override void OnCollide(Collider2D coll)
   {
        //GameManager.instance;
        /*
        if (coll.name == "Act")
        {
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
        */
   }
}
