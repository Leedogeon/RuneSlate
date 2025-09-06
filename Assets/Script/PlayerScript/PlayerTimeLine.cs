using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Timeline;

public class PlayerTimeLine : MonoBehaviour
{
    public static PlayerTimeLine Instance;

    private PlayableDirector Pd;
    public TimelineAsset[] Ta;
    public CinemachineBrain cinemachineBrain;

    // 카메라 적용
    int num = 1;
    private void Start()
    {
        Instance = this;
        Pd = GetComponent<PlayableDirector>();
        cinemachineBrain = FindObjectOfType<FollowCamera>().GetComponent<CinemachineBrain>();
        TimelineAsset timeline = Pd.playableAsset as TimelineAsset;

        GameManager gameManager = FindObjectOfType<GameManager>();
        SignalReceiver signalReceiver = FindObjectOfType<GameManager>().GetComponent<SignalReceiver>();
        // 타임라인의 모든 트랙을 순회합니다.
        foreach (var trackOutput in timeline.outputs)
        {
            // 트랙의 이름이 "Signal Track"인지 확인합니다.
            // Timeline 에디터에서 Signal Track의 이름을 확인해야 합니다.
            if (trackOutput.streamName == "Signal Track") // 또는 다른 Signal Track 이름
            {
                // Signal Track을 GameManager와 바인딩합니다.
                Pd.SetGenericBinding(trackOutput.sourceObject, signalReceiver);
                Debug.Log("Timeline의 Signal Track이 GameManager의 Signal Receiver와 성공적으로 연결되었습니다.");
                break;
            }
        }

        foreach (var trackOutput in timeline.outputs)
        {
            // 트랙의 이름이 "Cinemachine Track"인지 확인합니다.
            // Timeline 에디터에서 해당 트랙의 이름을 정확히 확인해야 합니다.
            if (trackOutput.streamName == "Cinemachine Track")
            {
                // 찾은 트랙에 CinemachineBrain을 바인딩합니다.
                Pd.SetGenericBinding(trackOutput.sourceObject, cinemachineBrain);
                Debug.Log("Timeline의 Cinemachine Track이 Main Camera와 성공적으로 연결되었습니다.");
                break;
            }
        }

        // 캠 바인딩
        foreach (var track in timeline.GetOutputTracks())
        {
            if (track is CinemachineTrack)
            {
                Debug.Log($"track = {track.name}");
                foreach (var clip in track.GetClips())
                {
                    CinemachineShot shot = clip.asset as CinemachineShot;
                    if (shot != null)
                    {
                        var vcamObj = GameObject.Find("Trigger1").transform.Find("Vc" + num);
                        num++;

                        if (vcamObj != null)
                        {
                            var vcam = vcamObj.GetComponent<CinemachineVirtualCamera>();
                            var exposedName = shot.VirtualCamera.exposedName;

                            Pd.SetReferenceValue(exposedName, vcam);

                            Debug.Log($"Clip {clip.displayName} 에 {vcam.name} 바인딩 완료");
                        }
                        else
                        {
                            Debug.LogWarning($"InactiveVCam{num - 1} 을 찾을 수 없습니다!");
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CutScene")
        {
            other.gameObject.SetActive(false);
            Pd.Play(Ta[0]);
        }
    }
}
