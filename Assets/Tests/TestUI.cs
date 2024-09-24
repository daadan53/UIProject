using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

[TestFixture]
public class TestUI
{
    // Test simple genre vrai ou faux --> EditMod ?
    [Test]
    public void TestUISimplePasses()
    {
        // Arrange
        var go = new GameObject();
        var uiMana = go.AddComponent<UI_Mana>();
 
        var uiDocument = go.AddComponent<UIDocument>();
        var visualTree = Resources.Load<VisualTreeAsset>("UI/NewUXMLTemplate"); // Charge le fichier UXML depuis les ressources

        // Act
        uiDocument.visualTreeAsset = visualTree;  // Associez le fichier UXML à l'UIDocument
        uiMana._Root = uiDocument.rootVisualElement;

        // Assert
        Assert.IsNotNull(uiMana._Root);
    }
}
