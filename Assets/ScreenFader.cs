using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadePanel; // 검은 패널 (Image 컴포넌트)
    public float fadeDuration = 2f; // 페이드 시간
    [SerializeField]GameObject TXT;
    public void FadeStart()
    {
        StartCoroutine(FadeOut());
    }
    public IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.5f);

        float elapsed = 0f;
        Color color = fadePanel.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / fadeDuration);
            fadePanel.color = color;
            yield return null;
        }

        TXT.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("RuneSlate_MainMenu");
    }

    public IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color color = fadePanel.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(elapsed / fadeDuration);
            fadePanel.color = color;
            yield return null;
        }
    }
}