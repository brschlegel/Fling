extends RigidBody2D

class_name Flingable

# Called when the node enters the scene tree for the first time.
func _ready():
	FlingableManager.register_flingable(self)
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _exit_tree():
	FlingableManager.unregister_flingable(self)
	
func select_to_fling():
	print(owner.name)
