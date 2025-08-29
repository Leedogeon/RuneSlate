using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 다른 스크립트에서 입력값을 받을수는 있지만, 수정은 불가능하게 캡슐화
    // 코드를 나눠서 제작중
    [SerializeField] PlayerInput input;
    [SerializeField] PlayerMovement Movement;
    [SerializeField] GameObject questionMark;
    private void Awake()
    {
        input = GetComponentInChildren<PlayerInput>();
        Movement = GetComponentInChildren<PlayerMovement>();
    }

    void Start()
    {
    }
    void Update()
    {

    }

    public void SpawnQuestionMark()
    {
        Vector3 qPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.3f, gameObject.transform.position.z);
        GameObject Mark = Instantiate(questionMark, qPos, Quaternion.identity);
        StartCoroutine(StopPlayer());
        Destroy(Mark,.3f);
    }
    public IEnumerator StopPlayer()
    {
        Time.timeScale = 0;
        // 실제시간을 체크
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
    }
}
