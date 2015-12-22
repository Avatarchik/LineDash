public enum BoardQuizAnimate{
		StandOpen,Close,AutoOpen
};
public class GameEvent{
	public const string GAME_START = "GAME_START";
	public const string GAME_PAUSE = "GAME_PAUSE";
	public const string CHANGE_COLOR = "CHANGE_COLOR";
	public const string GAME_MANAGER_INIT = "GAME_MANAGER_INIT";
}
public class SpawnEvent{
	public const string SPAWN_OBJECT = "SPAWN_OBJECT";
}
public class DataEvent{
		public static readonly string DATA_UPDATE = "DataUpdate";
		public static readonly string LOAD_JSON_COMPLETE = "LoadJsonComplete";
}
public class StoreEvent{
		public static readonly string STORE_INITIALIZED = "StoreInitialized";
		public static readonly string TAKE_EXAMPLE = "TakeExample";
}
public class PopupEvent{
		public static readonly string OPEN  = "PopupOpen";
		public static readonly string CLOSE  = "PopupClose";
}
public class PlayerEvent{
	public static readonly string PLAYER_LOAD_COMPLETE = "PlayerLoadComplete";
	public static readonly string PLAYER_HIT_GOAL = "PlayerHitGoal";	
	public static readonly string PLAYER_START = "PlayerStart";
	public const string GET_GEM = "GET_GEM";
		//Hitobject
	public static readonly string HIT_SPIKE = "HitSpike";

}
public class AdsEvent{
		public static readonly string ADS_COMPLETE = "AdsComplete";
		public static readonly string ADS_SKIP = "AdsSkip";
		public static readonly string ADS_FAIL = "AdsFail";
}
public class AdsMode{
		public static readonly string ADS_SKIPGAME = "AdsSkipGame";
		public static readonly string ADS_GETREWARDSHOP = "AdsGetRewardShop";

}
public class SoundEvent{
		public static readonly string CLICK = "Click";
		public static readonly string CORRECT = "Correct";
		public static readonly string WRONG = "Wrong";
		public static readonly string OPEN_BOARD = "Open_Board";
}
public class SceneEvent{
	public static readonly string REPLAY = "Replay";
	public static readonly string TO_MENU = "Tomenu";
	public static readonly string NEXT_LEVEL = "NextLevel";
	public static readonly string GAME_START = "GameStart";

}
public enum scenemode{
	gamestart = 0,Replay = 1,tomenu =2,nextlevel = 3

}
