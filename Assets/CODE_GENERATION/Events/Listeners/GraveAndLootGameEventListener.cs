using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "GraveAndLoot")]
	public sealed class GraveAndLootGameEventListener : BaseGameEventListener<GraveAndLoot, GraveAndLootGameEvent, GraveAndLootUnityEvent>
	{
	}
}