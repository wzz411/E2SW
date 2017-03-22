public class NodeInfo {

	//Node Identification
	public int direction; //N = 0, E = 1, S = 2, W = 3, Center = 4;
	public int level;
	public int order;
	public string name;

	//Node information
	public bool isClicked; //Clicked = 1 or true, Unclicked = 0 or false;
	public bool isHidden; //Hidden = 1 or true, Not Hidden = 0 or false;

	//Constructor
	public NodeInfo (int _direction, int _level, int _order, string _name, bool _isHidden) {
		direction = _direction;
		level = _level;
		order = _order;
		name = _name;
		isHidden = _isHidden;
		isClicked = false;
	}


	//Methods

	//set method for isClicked
	public void setIsClicked (bool _isClicked) {
		isClicked = _isClicked;
	}


	//get method for isClicked
	public bool geIsClicked () {
		return isClicked;
	}

	override
	public string ToString() {

		string directionStr = "";

		switch (direction) {
		case 0:
			directionStr = "North";
			break;
		case 1:
			directionStr = "East";
			break;
		case 2:
			directionStr = "South";
			break;
		case 3:
			directionStr = "West";
			break;
		default:
			directionStr = "Center";
			break;
		}

		return "Direction : " + directionStr + ", Level : " + level + ", Order : " + order + ", name: " + name;
	}
}
