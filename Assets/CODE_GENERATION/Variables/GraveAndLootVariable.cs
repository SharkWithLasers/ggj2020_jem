using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "GraveAndLootVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Custom/GraveAndLoot",
	    order = 120)]
	public class GraveAndLootVariable : BaseVariable<GraveAndLoot>
	{
	}
}