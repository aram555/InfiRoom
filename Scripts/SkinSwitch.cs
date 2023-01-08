using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSwitch : MonoBehaviour
{
    public Transform skins;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("Index");
        SwitchSkin(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchSkin(int index) {
        for(int i = 0; i < skins.childCount; i++) {
            if(skins.GetChild(i).name != "Orientation") skins.GetChild(i).gameObject.SetActive(true);
            if(i != index) skins.GetChild(i).gameObject.SetActive(false);
            else skins.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Left() {
        index--;
        if(index < 0) index = skins.childCount-1;
        SwitchSkin(index);
        PlayerPrefs.SetInt("Index", index);
    }

    public void Right() {
        index++;
        if(index > skins.childCount-1) index = 0;
        SwitchSkin(index);
        PlayerPrefs.SetInt("Index", index);
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
