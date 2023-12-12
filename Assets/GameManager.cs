using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int multiplier;
    [SerializeField] public int currency;
    [SerializeField] public int baseAmount;
    [SerializeField] private AnimationManager animManager;
    [SerializeField] public TMP_Text currencyText;
    [SerializeField] public int moreFoodLevel;

    [SerializeField] private TMP_Text moreFoodLevelText;
    [SerializeField] private TMP_Text moreFoodCostText;


    [SerializeField] private TMP_Text autoClickerLevelText;
    [SerializeField] private TMP_Text autoClickerCostText;
    [SerializeField] private float autoClickTime;
    [SerializeField] public int autoClickLevel;
    [SerializeField] private TMP_Text autoClickTiming;

    private float timer;
    private float timer2;
    private int currentFoodCost;
    private int currentAutoClickCost;


    // Start is called before the first frame update
    void Start()
    {
        moreFoodLevel = 1;
        autoClickLevel = 1;
        autoClickTime = 12;
        timer2 = autoClickTime;
        currentFoodCost = moreFoodLevel * 50 * multiplier;
        moreFoodCostText.SetText("Cost: " + currentFoodCost.ToString());
        currentAutoClickCost = autoClickLevel * 80 * multiplier;
        autoClickerCostText.SetText("Cost: " + currentAutoClickCost.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(autoClickLevel > 1)
        {
            timer += Time.deltaTime;
            autoClickTiming.SetText((timer2 -= Time.deltaTime).ToString());
            if (timer >= autoClickTime)
            {
                autoClicker();
                timer2 = autoClickTime;
                timer = 0;
            }
        }

    }

    public int addCurrencyAmount()
    {
        return baseAmount * multiplier;
    }

    public bool purchaseMoreFood()
    {
        if (currency < currentFoodCost)
            return false;
        else
            return true;
    }

    public bool purchaseAutoClicker()
    {
        if (currency < currentAutoClickCost)
            return false;
        else
            return true;
    }

    public void tapKitty()
    {
        currency += baseAmount * multiplier;
        currencyText.SetText(currency.ToString());
    }

    public void buyAutoClicker()
    {
        autoClickLevel++;
        autoClickTime -= autoClickLevel;
        currency -= currentAutoClickCost;

        autoClickerLevelText.SetText("Level: " + autoClickLevel.ToString());
        currentAutoClickCost = autoClickLevel * 80 * multiplier;
        autoClickerCostText.SetText("Cost: " + currentAutoClickCost.ToString());
        currencyText.SetText(currency.ToString());
    }

    public void buyMoreFood()
    {
        moreFoodLevel++;
        multiplier += 1;
        currency -= currentFoodCost;

        moreFoodLevelText.SetText("Level: " + moreFoodLevel.ToString());
        currentFoodCost  = moreFoodLevel * 50 * multiplier;
        moreFoodCostText.SetText("Cost: " + currentFoodCost.ToString());
        currencyText.SetText(currency.ToString());
    }

    public void autoClicker()
    {
        animManager.autoClickerText();
        currency += baseAmount * multiplier;
        currencyText.SetText(currency.ToString());
    }
}
