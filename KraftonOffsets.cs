
namespace RingKraftonLoader
{
	/// <summary>
	/// RVAs e offsets de campo para a build anotada (ex. 2603.1.2.7). Globais do módulo em <c>GAME_*</c>;
	/// membros de struct/classe Unreal em <c>OFF_*</c>. Valores vêm do dump/SDK/fórum — atualizar quando o jogo mudar.
	/// </summary>
	internal class KraftonOffsets
	{
		// ── Kernel / Processo ───────────────────────────────────────
		public const int EPROCESS_DIR_TABLE_BASE = 0x28;

		// ============================================================
		//  OFFSETS DO JOGO — versao 2603.1.2.7 (C# Version)
		// ============================================================

		public const ulong GAME_UWORLD = 0x114B7E28;
		public const ulong GAME_UWORLD_IDA = 0x85027E28;   // fallback IDA (nao mapeado neste processo)
		public const ulong GAME_GATE_IDA = 0x83643900;
		public const ulong GAME_DECRYPT = 0xFAD3D28;   // XenuineDecrypt 2603.1.2.7
		public const ulong GAME_GNAMES = 0x11732A90;
		public const ulong GAME_GNAMES_OFFSET = 0x10;
		public const uint GAME_ELEMENTS_PER_CHUNK = 0x3E4C;
		public const ulong GAME_GOBJECTS = 0x11478CF0;

		// ── UWorld ───────────────────────────────────────────────────
		public const uint OFF_CURRENT_LEVEL = 0x800;    // UWorld → ULevel* (decrypt)
		public const uint OFF_GAME_INSTANCE = 0x3B0;    // UWorld → UGameInstance* (decrypt)
		public const uint OFF_GAME_STATE = 0x278;    // UWorld → AGameState* (decrypt)
		public const uint OFF_TIME_SECONDS = 0x810;    // UWorld → float TimeSeconds

		// ── UGameInstance ─────────────────────────────────────────────
		public const uint OFF_LOCAL_PLAYERS_DATA = 0xF0;     // GameInstance → ULocalPlayer* array data (NO decrypt)

		// ── ULevel / Actors ──────────────────────────────────────────
		public const uint OFF_ACTORS = 0x38;     // ULevel → TArray<AActor*> data (decrypt)
		public const uint OFF_ACTORS_COUNT = 0x40;     // TArray → int NumElements
		public const uint OFF_ACTORS_FOR_GC = 0x7D0;    // ULevel → ActorsForGC
		public const uint OFF_TARRAY_DATA = 0x0;  // TArray header -> Data
		public const uint OFF_TARRAY_NUM = 0x8;   // TArray header -> Num

		// ── AGameState ───────────────────────────────────────────────
		public const uint OFF_PLAYER_ARRAY = 0x410;    // GameState → TArray<APlayerState*>
		public const uint OFF_NUM_ALIVE_TEAMS = 0x480;    // GameState → int
		public const uint OFF_FEATURE_REP_OBJECT = 0xCF0;    // GameState → FeatureRepObject

		// ── SafeZone (em FeatureRepObject) ───────────────────────────
		public const uint OFF_SAFE_ZONE_POS = 0xB0;     // FeatureRepObject → FVector SafetyZonePosition
		public const uint OFF_SAFE_ZONE_RADIUS = 0xBC;     // FeatureRepObject → float SafetyZoneRadius
		public const uint OFF_BLUE_ZONE_POS = 0xC0;     // FeatureRepObject → FVector BlueZonePosition
		public const uint OFF_BLUE_ZONE_RADIUS = 0xCC;     // FeatureRepObject → float BlueZoneRadius

		// ── APlayerController / Camera ───────────────────────────────
		public const uint OFF_PLAYER_CONTROLLER = 0x38;     // LocalPlayer → APlayerController* (decrypt)
		public const uint OFF_ACKNOWLEDGED_PAWN = 0x4A8;    // PlayerController → APawn* (decrypt)
		public const uint OFF_PLAYER_CAMERA_MANAGER = 0x4D0;    // PlayerController → CameraManager  (NO decrypt)
		public const uint OFF_SHOW_MOUSE_CURSOR = 0x480;      // PlayerController → bool bShowMouseCursor
		public const uint OFF_VIEW_TARGET = 0x1050;   // PlayerController → ViewTarget     (decrypt)
		public const uint OFF_CAMERA_FOV = 0xA2C;    // CameraManager → float FOV
		public const uint OFF_CAMERA_ROT = 0xA10;    // CameraManager → FRotator
		public const uint OFF_CAMERA_POS = 0xA30;    // CameraManager → FVector

		// ── APlayerState ─────────────────────────────────────────────
		public const uint OFF_PLAYER_STATE = 0x418;    // APawn → APlayerState*
		public const uint OFF_PLAYER_NAME = 0x420;    // APlayerState → FString PlayerName
		public const uint OFF_ACCOUNT_ID = 0;

		// ── APawn / USceneComponent (usado na lista de jogadores) ──
		public const uint OFF_ROOT_COMPONENT = 0x308;      // AActor → USceneComponent* (decrypt)
		public const uint OFF_COMPONENT_LOCATION = 0x330;  // USceneComponent → FVector

		// ── APawn (LessonCheating / PAOD — mesma build que OFF_* acima) ─────────
		public const uint OFF_LAST_TEAM_NUM = 0x2C18;      // APawn → int LastTeamNum
		public const uint OFF_SPECTATED_COUNT = 0x113C;    // APawn → int (espectadores no jogador local)

		// ── Mesh / ossos (2603.1.2.7) — doc DMA: Mesh em geral sem decrypt; Mesh3P = malha 3ª pessoa ──
		public const uint OFF_MESH = 0x4A0;                      // ACharacter → USkeletalMeshComponent*
		public const uint OFF_MESH3P = 0x800;                    // Malha 3P (fallback se Mesh inválido)
		public const uint OFF_COMPONENT_TO_WORLD = 0x320;         // USceneComponent → FTransform
		/// <summary>UStaticMesh* no dump — não confundir com TArray de ossos.</summary>
		public const uint OFF_STATIC_MESH = 0xAE8;
		public const uint OFF_BONE_COUNT = 0xAF0;
		public const uint OFF_BOUND_BOX = 0x228;
		public const uint OFF_GENDER = 0xAC8;
		public const uint OFF_ANIM_SCRIPT_INSTANCE = 0xE30;

		// ── Visible check — floats no USkeletalMeshComponent (UPrimitive), forum / dump atual ──
		// NÃO usar 0x6A0/0x6A8 nesta linha de build: no dump Krafton os Last* costumam estar deslocados.
		// Fórum: LastSubmitTime=0x758, LastRenderTimeOnScreen=0x75C (0x75C ≠ “Eyes” noutra classe).
		public const uint OFF_DMA_LAST_SUBMIT_TIME = 0x758;
		public const uint OFF_DMA_LAST_RENDER_TIME_ON_SCREEN = 0x75C;

		/// <summary>Visible check só roda quando <see cref="OFF_DMA_LAST_RENDER_TIME_ON_SCREEN"/> ≠ 0.</summary>
		public static bool DmaVisibleCheckOffsetsReady => OFF_DMA_LAST_RENDER_TIME_ON_SCREEN != 0;

		/// <summary>
		/// PAOD GetBoneTable1: lê TArray em mesh + offset_ComponentSpaceTransforms (netvars exemplo 2752 = 0xAC0).
		/// Class.cpp GetComponentSpaceTransformsArray(i): mesh + (offset_USkinnedMeshComponent_MasterPoseComponent + 8) + i * sizeof(TArray) — buffer duplo consecutivo (+16).
		/// </summary>
		public const uint OFF_COMPONENT_SPACE_TRANSFORMS_PAOD = 0xAC0;

		/// <summary>Bases do primeiro TArray; o segundo buffer fica em base+0x10 (stride TArray 64-bit).</summary>
		public static readonly uint[] OFF_COMPONENT_SPACE_TRANSFORMS_BASES =
		{
			0xAE8,
			OFF_COMPONENT_SPACE_TRANSFORMS_PAOD,
			0x9C8, 0xA18, 0x9A8, 0xA08, 0x9B0, 0xA68, 0x8E0,
			0x980, 0xA00, 0xAA0, 0xAB8, 0xB00,
		};

		/// <summary>Scan no USkeletalMeshComponent quando offset do TArray não está na lista (alinhado 8).</summary>
		public const uint SCAN_MESH_TARRAY_MIN = 0x80;
		public const uint SCAN_MESH_TARRAY_MAX = 0xD00;

		// ── Vida (HealthDecipher + GetHealth — build atual) ─────────────────────
		public const uint OFF_HEA_FLAG = 0x3B9;
		public const uint OFF_HEALTH1 = 0xA3C;
		public const uint OFF_HEALTH2 = 0xA38;
		public const uint OFF_HEALTH3 = 0xA24;
		public const uint OFF_HEALTH4 = 0xA10;
		public const uint OFF_HEALTH5 = 0xA25;
		public const uint OFF_HEALTH6 = 0xA20;
		public const uint OFF_GROGGY_HEALTH = 0x14C0;
	}
}
