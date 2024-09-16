using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TestUiPlayMod
{
    GameObject go;
    UI_Mana uiMana;

    [SetUp]
    public void SetUp()
    {
        go = new GameObject();
        uiMana = go.AddComponent<UI_Mana>();
    }

    [TearDown]
    public void TearDown()
    {

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EmptyField()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.

        //uiMana.TestEmptyField();

        yield return null;

    }
}
