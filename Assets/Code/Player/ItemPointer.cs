using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPointer : MonoBehaviour
{
  public class Entry {
    public GameObject pointer;
    public Transform pointingAt;
  }

  public GameObject pointerPrefab;

  [SerializeField] private LevelProcGeneration levelProcGen;

  [SerializeField] private PlayerMeta playerMeta;

  private List<Entry> pointers = new List<Entry>();

  private bool showPointers = false;

  private void Start()
  {
  }

  private void Update()
  {
    if (showPointers)
    {
      for (int i = 0; i < pointers.Count; i++)
      {
        if (pointers[i].pointingAt != null) {
          PointAt(pointers[i]);
        }
      }
    }
    else
    {
      if (
        Input.GetAxisRaw($"{playerMeta.InputPrefix}Horizontal") != 0 ||
        Input.GetAxisRaw($"{playerMeta.InputPrefix}Vertical") != 0
      )
      {
        showPointers = true;
        for (int i = 0; i < 3; i++)
        {
          Entry entry = new Entry();
          entry.pointer = Instantiate(pointerPrefab, transform);
          entry.pointingAt = null;

          pointers.Add(entry);
        }
        InitializePointers();
      }
    }
  }

  private void InitializePointers()
  {
    List<Grave> graves = levelProcGen.GetGraves();
    for (int i = 0; i < 3; i++)
    {
      UpdatePointer(graves[i].transform);
    }
  }

  private void PointAt(Entry pointer)
  {
    Vector3 toPosition = pointer.pointingAt.position;
    Vector3 fromPosition = transform.position;
    fromPosition.z = 0f;
    Vector3 direction = (toPosition - fromPosition).normalized;
    float angle = Vector3.Angle(direction, transform.forward);

    pointer.pointer.transform.localEulerAngles = new Vector3(0, 0, angle);
  }

  private void ResetPointers()
  {
    pointers.ForEach(pointer => pointer.pointingAt = null);
  }

  private void UpdatePointer(Transform objectToPointAt)
  {
    Entry pointerToUpdate = ResolveUnusedPointer();

    if (pointerToUpdate == null)
    {
      return;
    }

    pointerToUpdate.pointingAt = objectToPointAt;
  }

  private Entry ResolveUnusedPointer()
  {
    for (int i = 0; i < pointers.Count; i++)
    {
      if (pointers[i].pointingAt == null) {
        return pointers[i];
      }
    }

    return null;
  }
}
