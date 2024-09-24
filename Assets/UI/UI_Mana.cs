using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_Mana : MonoBehaviour
{
    public VisualElement _Root; //Base du fichier UXML et permet d'accès à toute la hiérarchie
    private Button _Button1;
    //private Label _Caption;
    private VisualElement _PanelEmptyField;
    public VisualTreeAsset _EmptyFieldTemplate;
    public VisualTreeAsset _EmptyFieldMail;
    public VisualTreeAsset _EmptyFieldMdp;
    private TextField _InputMail;
    private TextField _InputPass;
    TemplateContainer templateContainer; //Contient l'instance des messages d'erreur
    private bool timerDestroy;
    private float timerContainer;
    private bool isClicked;

    // On va injecter toute nos ref
    private void Awake() 
    {
        _Root = GetComponent<UIDocument>().rootVisualElement; // Le script doit se trouver au meme nv que le UI doc

        _Button1 = _Root.Q<Button>("button1");

        //_Caption = _Root.Q<Label>("caption");

        _PanelEmptyField = _Root.Q<VisualElement>("panelEmptyField");
        _InputMail = _Root.Q<TextField>("inputMail");
        _InputPass = _Root.Q<TextField>("inputPass");

        //_PanelEmptyField.AddToClassList("invisible"); // Ajoute le selecteur dans 
        //labelMailMdp = _EmptyFieldTemplate.Q<Label>("Mail et Mdp");

        timerDestroy = false;
        isClicked = false;

        // Là on charge les événemment qui se produiront à l'appuie (clicked est une fonction déjà predef pour detect le click)
        _Button1.clicked += Button1_clicked;

    }

    private void Update() 
    {
        if(timerDestroy)
        {
            timerContainer += Time.deltaTime;
        }
        else 
        {
            timerContainer = 0;
        }

        if( timerContainer >= 3 )
        {
            isClicked = false;
            timerDestroy = false;
            // Destroy 
            templateContainer.Clear();
        }
    }

    // Fonction à l'appui sur le bouton
    private void Button1_clicked()
    {
        if(!timerDestroy && !isClicked)
        {
            TestEmptyField();

            //On demarre un timer
            timerDestroy = true;
        }

        isClicked = true;
    }

    // Méthode pour tester la barre de progrès et instancier
    public void TestEmptyField()
    {
        switch ((_InputMail.value, _InputPass.value))
        {
            // Il manque adresse mail, et mdp
            case ("", ""):
                if (templateContainer != null)
                {
                    templateContainer = null;
                }
                templateContainer = _EmptyFieldTemplate.Instantiate(); // Instancier un champ avec le texte du panel
                _PanelEmptyField.Add(templateContainer); // Ajouter au panel pour l'affichage
                break;

            // Il manque seulement l'adresse mail
            case ("", _):
                if (templateContainer != null)
                {
                    templateContainer = null;
                }
                templateContainer = _EmptyFieldMail.Instantiate(); // Instancier un champ pour l'adresse mail manquante
                _PanelEmptyField.Add(templateContainer);
                break;

            // Il manque seulement le mdp
            case (_, ""):
                if (templateContainer != null)
                {
                    templateContainer = null;
                }
                templateContainer = _EmptyFieldMdp.Instantiate(); // Instancier un champ pour le mdp manquant
                _PanelEmptyField.Add(templateContainer);
                break;

            // Les deux champs sont remplis
            default:
                Destroy(gameObject);
                Debug.Log("C'est réussi !");
                break;
        }
        
    }
}
