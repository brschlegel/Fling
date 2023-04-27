extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _show_main_menu(b : bool):
	get_node("Main Menu").visible = b

func _show_game_over(b: bool):
	get_node("Game Over").visible = b


func _on_start_game_pressed():
	_show_main_menu(false)
	pass # Replace with function body.

func _on_game_end():
	_show_game_over(true)

func _on_main_menu():
	_show_main_menu(true)
	_show_game_over(false)


