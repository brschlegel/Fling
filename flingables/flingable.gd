extends RigidBody2D

class_name Flingable

var selected : bool = false

var min_force : float = 400
var max_force : float = 1000
var dist_to_force : float = 3

var velocity_to_select_threshold : float = 4

@onready var shot_indicator : ShotIndicator = $ShotIndicator

# Called when the node enters the scene tree for the first time.
func _ready():
	FlingableManager.register_flingable(self)
	shot_indicator.enable(false)
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if selected:
		var max_dist := (max_force - min_force) / dist_to_force
		var ratio := clampf(MouseManager.current_position.distance_to(global_position) / max_dist, 0, 1)
		shot_indicator.update_line(-global_position.direction_to(MouseManager.current_position), ratio)
	if linear_velocity.length() < velocity_to_select_threshold:
		get_node("AnimatedSprite2D").modulate = Color.WHITE
	else:
		get_node("AnimatedSprite2D").modulate = Color.DARK_GRAY
	pass

func _exit_tree():
	FlingableManager.unregister_flingable(self)
	
func select_to_fling():
	selected = true
	shot_indicator.enable(true)
	MouseManager.onMouseButtonRelease.connect(fling)
	#print(owner.name)

func fling():
	shot_indicator.enable(false)
	var force := clampf(MouseManager.current_position.distance_to(global_position) * dist_to_force, min_force, max_force)
	apply_central_impulse(-global_position.direction_to(MouseManager.current_position) * force)
	MouseManager.onMouseButtonRelease.disconnect(fling)
	
