extends Node

var isHeld := false
var current_position := Vector2.ZERO

signal onMouseButtonPress
signal onMouseButtonRelease
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _input(event):
	if event is InputEventMouseButton:
		if event.pressed:
			if !isHeld:
				onMouseButtonPress.emit()
			isHeld = true
		else:
			if isHeld:
				onMouseButtonRelease.emit()
			isHeld = false
	if event is InputEventMouseMotion:
		current_position = event.position
