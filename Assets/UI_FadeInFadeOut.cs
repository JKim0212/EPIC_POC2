using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_FadeInFadeOut : MonoBehaviour
{
    Image _fadeImage;
    [SerializeField] float fadeinfadeoutTime;
    [SerializeField] float stayTime;

    private void Start()
    {
        _fadeImage = GetComponentInChildren<Image>();
        Color c = _fadeImage.color;
        c.a = 0f;
        _fadeImage.color = c; // Ensure it starts invisible
    }

    public void FadeinFadeout()
    {
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        // Fade In
        float timer = 0f;
        while (timer < fadeinfadeoutTime)
        {
            float alpha = timer / fadeinfadeoutTime;
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SetAlpha(1f); // Ensure it's fully visible

        Debug.Log("Fade In");
        // Stay visible
        UIManager.Instance.ChangeToFinishBuild();
        yield return new WaitForSeconds(stayTime);

        // Fade Out
        timer = 0f;
        while (timer < fadeinfadeoutTime)
        {
            float alpha = 1f - (timer / fadeinfadeoutTime);
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SetAlpha(0f); // Ensure it's fully transparent
    }

    void SetAlpha(float alpha)
    {
        Color c = _fadeImage.color;
        c.a = Mathf.Clamp01(alpha);
        _fadeImage.color = c;
    }
}
