using UnityEngine;
using TMPro;
using System.Collections;

public class VildanLesson : MonoBehaviour
{
    public TextMeshProUGUI lessonText;
    public Transform vildanTeacher;

    private bool started = false;

    private void OnTriggerEnter(Collider other)
    {
        if (started) return;

        if (other.CompareTag("Player"))
        {
            started = true;
            StartCoroutine(StartLesson());
        }
    }

    IEnumerator StartLesson()
    {
        lessonText.gameObject.SetActive(true);
        lessonText.text = "VILDAN DERSI BASLADI";
        yield return new WaitForSeconds(2f);
        lessonText.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        StartCoroutine(VildanLookRoutine());
    }

    IEnumerator VildanLookRoutine()
    {
        while (true)
        {
            // Vildan tahtaya döner: güvenli
            vildanTeacher.rotation = Quaternion.Euler(0, 0, 0);

            lessonText.gameObject.SetActive(true);
            lessonText.text = "VILDAN TAHTAYA DONDU";
            yield return new WaitForSeconds(1.5f);
            lessonText.gameObject.SetActive(false);

            yield return new WaitForSeconds(Random.Range(4f, 8f));

            // Vildan öğrencilere döner: tehlike
            vildanTeacher.rotation = Quaternion.Euler(0, 180, 0);

            lessonText.gameObject.SetActive(true);
            lessonText.text = "TABLET ZU!";
            yield return new WaitForSeconds(1.5f);
            lessonText.gameObject.SetActive(false);

            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
    }
}