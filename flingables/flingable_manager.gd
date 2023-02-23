extends Node

@export
var dist_to_select_threshold : float = 30
@export 
var velocity_to_select_threshold: float = 4
var flingables : Array[Node2D]
# Called when the node enters the scene tree for the first time.
func _ready():
	MouseManager.onMouseButtonPress.connect(on_mouse_pressed)
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
	

func register_flingable(f):
	flingables.append(f)

func unregister_flingable(f):
	flingables.remove_at(flingables.find(f))
	
func on_mouse_pressed():
	var minDist := 999999
	var closest
	for f in flingables:
		var dist := f.global_position.distance_to(MouseManager.current_position)
		if dist <= dist_to_select_threshold and f.linear_velocity.length() <= velocity_to_select_threshold:
			if(dist <= minDist):
				closest = f
				minDist = dist
	if closest != null:
		closest.select_to_fling()
