﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObjectsOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;
    
    

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }
    private const float k_PrefabRotation = 180.0f;
    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action OnObjectPlaced;

    ARRaycastManager m_RaycastManager;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    
    [SerializeField]
    int m_MaxNumberOfObjectsToPlace = 1;

    int m_NumberOfPlacedObjects = 0;

    public GameObject NotificationUI;
    public GameObject BackButtonUI;

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }
    
    public static bool IsDoubleTap(){
        bool result = false;
        float MaxTimeWait = 1;
        float VariancePosition = 1;
 
        if( Input.touchCount == 1  && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float DeltaTime = Input.GetTouch (0).deltaTime;
            float DeltaPositionLenght=Input.GetTouch (0).deltaPosition.magnitude;
 
            if ( DeltaTime> 0 && DeltaTime < MaxTimeWait && DeltaPositionLenght < VariancePosition)
                result = true;                
        }
        return result;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (IsDoubleTap())
            {
                if (m_RaycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = s_Hits[0].pose;

                    if (m_NumberOfPlacedObjects < m_MaxNumberOfObjectsToPlace)
                    {
                        spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                        spawnedObject.AddComponent<CSharpscaling>();
                        spawnedObject.AddComponent<rotateController>();
                        spawnedObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);
                        spawnedObject.transform.localScale = new Vector3(spawnedObject.transform.localScale.x,
                            spawnedObject.transform.localScale.y, spawnedObject.transform.localScale.z);
                        m_NumberOfPlacedObjects++;
                        NotificationUI.SetActive(false);
                        BackButtonUI.SetActive(true);
                    }
                    else
                    {
                        spawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
                        spawnedObject.transform.Rotate(0, k_PrefabRotation, 0, Space.Self);
                    }

                    OnObjectPlaced?.Invoke();
                }
            }
        }
    }
    public void UpdateModel(GameObject gameObject)
    {
        m_PlacedPrefab = gameObject;
    }
}
