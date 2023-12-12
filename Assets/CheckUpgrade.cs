using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckUpgrade : MonoBehaviour
{
    [SerializeField]
    private enum buttonType
    {
        NONE,
        MOREFOOD,
        AUTOCLICKER
    }
    [SerializeField] private buttonType type;
    private GameManager gameManager;
    private Button currButton;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case buttonType.MOREFOOD:
                currButton.interactable = gameManager.purchaseMoreFood();
                break;
            case buttonType.AUTOCLICKER:
                currButton.interactable = gameManager.purchaseAutoClicker();
                break;
        }


    }
}
