using System;
using System.Linq;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
	[Header("Asset References")]

	[SerializeField]
	InputReader _inputReader;

	[SerializeField]
	TransformEventChannelSO _playerInstantiatedChannel;

	[SerializeField]
	TransformAnchor _playerTransformAnchor;

	void Start()
	{
		_playerInstantiatedChannel.OnEventRaised += TrackPlayer;
	}

	void TrackPlayer(Transform playerTransform)
	{
		_playerTransformAnchor.Transform = playerTransform;

		_inputReader.EnableGameplayInput();

		_playerInstantiatedChannel.OnEventRaised -= TrackPlayer;
	}
}
