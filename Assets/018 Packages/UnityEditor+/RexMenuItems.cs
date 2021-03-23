using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class RexMenuItems : MonoBehaviour {

	[MenuItem("Assets/Create/GameFolders with the shortcut key %#n")]
	private static void CreateGameFolders () {
		
		Directory.CreateDirectory(Application.dataPath + "/Name/Animations"); // Create the folders Name and Animations if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Audio/Music"); // Create the folders Name, Audio and Music if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Audio/SFX"); // Create the folders Name, Audio and SFX if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Assets/Sprites/Animated_Spritesheets"); // Create the folders Name, Assets, Sprites and Animated_Spritesheets if them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Assets/Sprites/Characters"); // Create the folders Name, Assets, Sprites and Characters if them dont exists		
		Directory.CreateDirectory(Application.dataPath + "/Name/Assets/Sprites/Tilesets"); // Create the folders Name, Assets, Sprites and Tilesets if them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Assets/Backgrounds"); // Create the folders Name, Assets and Backgrounds if them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Fonts"); // Create the folders Name and Fonts if neither them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Materials"); // Create the folders Name and Materials if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Prefabs"); // Create the folders Name and Prefabs if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Scenes"); // Create the folders Name and Scenes if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/Scripts"); // Create the folders Name and Scripts if neither of them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/TileMap/Tiles/CustomTiles"); // Create the folders Name, TileMap, Tiles and CustomTiles if them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/TileMap/Palettes"); // Create the folders Name, TileMap and Palettes if them dont exists
		Directory.CreateDirectory(Application.dataPath + "/Name/TileMap/Brushes"); // Create the folders Name, TileMap and Brushes if them dont exists

		#if UNITY_EDITOR
		AssetDatabase.Refresh (); // Refresh the asset database so that it appears on the asset menu as soon as posible
		#endif

	}

}
