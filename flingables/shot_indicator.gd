class_name ShotIndicator
extends Node2D

@export
var background_length : float = 100

@onready var _background_line : Line2D = $BackgroundLine
@onready var _filler_line : Line2D = $FillerLine
# Called when the node enters the scene tree for the first time.
func _ready():
	_background_line.clear_points()
	_background_line.add_point(Vector2.ZERO, 0)
	_background_line.add_point(Vector2.RIGHT, 1)
	
	_filler_line.clear_points()
	_filler_line.add_point(Vector2.ZERO, 0)
	_filler_line.add_point(Vector2.RIGHT, 1)
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func update_line(dir : Vector2, ratio : float):
	_background_line.set_point_position(0, Vector2.ZERO)
	_background_line.set_point_position(1, dir.normalized() * background_length)
	_filler_line.set_point_position(0, Vector2.ZERO)
	_filler_line.set_point_position(1, dir.normalized() * background_length * ratio)
	
	
func enable(val : bool):
	set_process(val)
	visible = val
	

