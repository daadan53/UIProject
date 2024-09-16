using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestUI
{
    // Test simple genre vrai ou faux --> EditMod ?
    [Test]
    public void TestUISimplePasses()
    {
        // Use the Assert class to test conditions
        var go = new GameObject();
        var uiMana = go.AddComponent<UI_Mana>();

        Assert.IsNotNull(uiMana._Root);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    /*[UnityTest]
    public IEnumerator TestUIWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
