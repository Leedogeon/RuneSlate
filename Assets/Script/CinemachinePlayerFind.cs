using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class CinemachinePlayerFind : TargetingScript
{
    [SerializeField]private CinemachineVirtualCamera Instance;
    [SerializeField] Transform player;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        Instance = this.GetComponent<CinemachineVirtualCamera>();
    }

    private void LateUpdate()
    {
        
        player = PlayerManager.Instance.PlayerInstance.transform;
        if (player == null) return;
        // offset으로 카메라 위치 조정
        // 각도는 우선 유니티 인스펙터에서 설정
        transform.position = player.position + offset;
        Instance.LookAt = player;

    }

/*    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private float fadeAlpha = 0.3f; // 맞았을 때의 투명도
    [SerializeField] private Color rayColor = Color.yellow;

    private RaycastHit hit;
    private Color originalColor;

    private List<Renderer> currentHits = new List<Renderer>();
    private List<Renderer> previousHits = new List<Renderer>();

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, rayDistance);

        // 이전 프레임 저장 → 비교용
        previousHits.Clear();
        previousHits.AddRange(currentHits);
        currentHits.Clear();

        foreach (var h in hits)
        {
            if (h.collider.gameObject.name == "Capsule") continue;

            if (player == null) return;

            float distToHit = Vector3.Distance(transform.position, h.point);
            float distToPlayer = Vector3.Distance(transform.position, player.position);
            if (distToHit > distToPlayer) continue;

            Renderer rend = h.collider.GetComponent<Renderer>();



            if (rend != null)
            {
                Debug.Log("object name = " + rend.gameObject.name);
                currentHits.Add(rend);

                // 새로운 오브젝트라면 투명 모드 적용
                if (!previousHits.Contains(rend))
                {
                    SetMaterialTransparent(rend.material);

                    Color c = rend.material.color;
                    c.a = fadeAlpha;
                    rend.material.color = c;
                }
            }
        }

        // 이번에 안 맞은 오브젝트는 복구
        foreach (var rend in previousHits)
        {
            if (!currentHits.Contains(rend))
            {
                ResetMaterial(rend); // 원래 상태 복구
            }
        }

        Debug.DrawRay(transform.position, transform.forward * rayDistance, rayColor);
    }

    private void SetMaterialTransparent(Material mat)
    {
        mat.SetFloat("_Mode", 2); // 2 = Fade, 3 = Transparent
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
    }

    private void ResetMaterial(Renderer rend)
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = rayColor;
        Gizmos.DrawSphere(transform.position + transform.forward * rayDistance, 0.2f);

        if (hit.collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 0.3f);
        }
    }*/
}
