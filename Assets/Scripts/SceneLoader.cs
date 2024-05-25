using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public byte sceneNumber;
    public Animator animator;
    public UniversalManager manager;
    public byte buttonID;
    public GameObject[] thingsToDisable;
    [SerializeField]
    AudioSource AS;
   
    public void onPress()
    {
        animator.gameObject.SetActive(true);
        animator.enabled = true;
        manager.gameType = buttonID;
        for(int i = 0;i<thingsToDisable.Length;i++)
            thingsToDisable[i].gameObject.SetActive(false);
        AS.Play();
        StartCoroutine(Load());
    }
    public void onCall()
    {
        animator.gameObject.SetActive(true);
        animator.enabled = true;
        //manager.gameType = buttonID;
        for (int i = 0; i < thingsToDisable.Length; i++)
            thingsToDisable[i].gameObject.SetActive(false);
    }

    public IEnumerator Load()
    {
        yield return Yielders.Get(3.5f);
        SceneManager.LoadScene(sceneNumber);
    }
    public void QuickLoad()
    {
        SceneManager.LoadScene(sceneNumber);   
    }
}
