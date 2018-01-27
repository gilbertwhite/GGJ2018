using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "FishBank", menuName = "GGJ/FishBank", order = 1)]
public class FishBank : ScriptableObject
{
	public List<FishData> FishTypes;
}

#if UNITY_EDITOR
[CustomEditor(typeof(FishBank))]
public class FishBankCustomEditor : Editor
{
	private FishBank m_Self;

	public void OnEnable()
	{
		m_Self = target as FishBank;
	}

	public override void OnInspectorGUI ()
	{
		EditorGUILayout.BeginVertical("Box");

		GUI.backgroundColor = Color.green;
		if (GUILayout.Button ("Add Fish:")) 
		{
			FishData newFish = ScriptableObject.CreateInstance (typeof(FishData)) as FishData;
			AssetDatabase.AddObjectToAsset(newFish, m_Self);
			//newFish.hideFlags = HideFlags.HideInHierarchy;
			m_Self.FishTypes.Add (newFish);
		}
		GUI.backgroundColor = Color.white;

		List<FishData> listToRemove = new List<FishData>();
		foreach(FishData fish in m_Self.FishTypes)
		{
			if (fish == null) {
				listToRemove.Add(fish);
				continue;
			}
			EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.BeginHorizontal();
			fish.FishType = EditorGUILayout.TextField("Fish Type:", fish.FishType, GUILayout.ExpandWidth(true));

			GUI.backgroundColor = Color.red;
			if (GUILayout.Button ("X", GUILayout.ExpandWidth(false))) 
			{
				listToRemove.Add(fish);
			}
			GUI.backgroundColor = Color.white;
			EditorGUILayout.EndHorizontal();

			fish.Color = EditorGUILayout.ColorField("Fish Color:", fish.Color);
			fish.Scale = EditorGUILayout.Vector3Field("Fish Scale:", fish.Scale);
			fish.Speed = EditorGUILayout.FloatField("Fish Speed:", fish.Speed);
			fish.AttractionDuration = EditorGUILayout.FloatField("Fish Attraction Duration:", fish.AttractionDuration);

			EditorGUILayout.EndVertical();
		}

		EditorGUILayout.EndVertical();

		foreach (FishData toRemove in listToRemove) 
		{
			Object.DestroyImmediate(toRemove, true);
			m_Self.FishTypes.Remove (toRemove);
		}
	}

	public void Destroy()
	{
		EditorUtility.SetDirty(m_Self);
		AssetDatabase.SaveAssets();
	}
}
#endif