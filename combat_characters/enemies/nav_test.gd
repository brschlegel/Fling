extends Node2D

var agents : Array
# Called when the node enters the scene tree for the first time.
func _ready():
	var children = get_children()
	for c in children:
		agents.append(c)
		print(agents.size())
	MouseManager.onMouseButtonPress.connect(on_mouse_pressed)
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func on_mouse_pressed():
	for a in agents:
		#print(MouseManager.current_position)
		#oo look at me calling C# methods in gdscript
		a.call("SetTargetLocation", MouseManager.current_position)
	
