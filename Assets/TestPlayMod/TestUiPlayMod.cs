using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TestUiPlayMod
{
    UIDocument uIDocument;  
    UI_Mana uI_Mana;

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EmptyField()
    {
        // On charge la scène et on attend
        SceneManager.LoadScene(0);

        yield return null; // A chque fois que j'attends quelque chose

        // On récup les visual elements

        uI_Mana._Root = uIDocument.rootVisualElement;

        yield return null;

        // On vérifie s'il y a bien un boutton

        Assert.IsNotNull(GameObject.Find("Button1"));

        yield return null;

        // On vérifie le clique

    }
}
