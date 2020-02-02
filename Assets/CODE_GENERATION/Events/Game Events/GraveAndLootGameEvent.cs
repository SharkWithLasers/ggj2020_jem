using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "GraveAndLootGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Custom/GraveAndLoot",
	    order = 120)]
	public sealed class GraveAndLootGameEvent : GameEventBase<GraveAndLoot>
	{
	}
}