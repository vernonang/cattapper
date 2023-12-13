using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using TMPro.Examples;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Sprite[] catSprites;
    [SerializeField] private Button clicker;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject autoClicktext;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject panel;
    [SerializeField] private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, catSprites.Length);
        clicker.GetComponent<Image>().sprite = catSprites[index];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void randomSkin()
    {
        int index = Random.Range(0, catSprites.Length);
        clicker.GetComponent<Image>().sprite = catSprites[index];

        GameObject obj = Instantiate(text, Input.mousePosition, Quaternion.identity);
        obj.transform.SetParent(panel.transform, false);

        Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        obj.transform.position = pos;

        GameObject obj2 = Instantiate(cat, Input.mousePosition, Quaternion.identity);
        obj2.transform.SetParent(panel.transform, false);

        obj2.GetComponent<Image>().sprite = catSprites[index];
        float scale = Random.Range(1f, 2f);
        obj2.transform.localScale = new Vector3(scale, scale, 0);
        obj2.transform.position = pos;
        obj2.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
    }

    public void autoClickerText()
    {
        Vector3 pos = new Vector3(Random.Range(-200, 200), clicker.gameObject.transform.position.y + 300, 0);
        GameObject obj = Instantiate(autoClicktext, pos, Quaternion.identity);
        obj.transform.SetParent(panel.transform, false);
    }
}
