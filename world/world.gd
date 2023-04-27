extends Node2D

@export
var level : PackedScene

signal game_over

var spawned_level
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
	
func _spawn_level():
	var instance = level.instantiate();
	add_child(instance);
	spawned_level = get_node("base_level")
	spawned_level.get_node("Door Stuff").get_node("DoorHealth").connect("Died", _on_door_die)
	
func _delete_level():
	spawned_level.queue_free()
	
func _on_door_die():
	game_over.emit()
	_delete_level()