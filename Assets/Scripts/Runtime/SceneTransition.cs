using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void HandlePlayClick () {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene () {
        animator.SetTrigger("TransitionStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
