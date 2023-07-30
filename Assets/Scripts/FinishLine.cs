using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject completedLevelScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject shadow;
    [SerializeField] private Animator shadowAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInput.enabled = false;
            shadow.GetComponent<ShadowController>().canMove = false;
            StartCoroutine(FadeOutShadow());

            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2) //-2 bc last index is the infinite runner mode
            {
                winScreen.SetActive(true);
            }
            else
            {
                completedLevelScreen.SetActive(true);
            }
        }
    }

    IEnumerator FadeOutShadow()
    {
        shadowAnim.Play("Fade out");
        yield return new WaitForSeconds(1.25f);
        Destroy(shadow);
    }
}
