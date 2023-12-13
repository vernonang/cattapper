using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationObject : MonoBehaviour
{
    [SerializeField] private enum objectType
    {
        NONE,
        TEXT,
        AUTOCLICKTEXT,
        IMAGE
    }
    [SerializeField] private objectType type;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (type == objectType.TEXT)
        {
            var text = GetComponent<TMP_Text>();
            text.SetText("+" + gameManager.addCurrencyAmount().ToString());
        }
        if (type == objectType.AUTOCLICKTEXT)
        {
            var text = GetComponent<TMP_Text>();
            text.SetText("+" + gameManager.addAutoClickAmount().ToString());

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == objectType.TEXT)
        {
            var text = GetComponent<TMP_Text>().color -= new Color(0, 0, 0, 1) * Time.deltaTime;
            transform.localPosition += new Vector3(0, 400, 0) * Time.deltaTime;
            if (text.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (type == objectType.AUTOCLICKTEXT)
        {
            var text = GetComponent<TMP_Text>().color -= new Color(0, 0, 0, 1) * Time.deltaTime;
            transform.localPosition += new Vector3(0, 300, 0) * Time.deltaTime;
            if (text.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (type == objectType.IMAGE)
        {
            var image = GetComponent<Image>().color -= new Color(0, 0, 0, 0.7f) * Time.deltaTime;
            if (image.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
