extends Node2D

var agents : Array[NavigationAgent2D]
# Called when the node enters the scene tree for the first time.
func _ready():
	var children = get_children()
	for c in children:
		agents.append(c.get_node("NavigationAgent2D"))
		print(agents.size())
	MouseManager.onMouseButtonPress.connect(on_mouse_pressed)
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func on_mouse_pressed():
	for a in agents:
		print(MouseManager.current_position)
		a.set_target_location(MouseManager.current_position)
	
