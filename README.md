# AI-Game
Gamedev assignment

Jamie Ray

A00252166

Game genre: basic scrolling shoot’em up style game

Gameplay: Defeat enemies acquire upgrades, defeat boss.

Features: Menu, Score, Healthbar, Upgrades(movement speed, shoot speed)
Enemies: Drone, Cherub, Fallen, Cross, Homing, Boss

Drone: Vertical movement only

Cherub: Pattern movement, left to right while descending. Has 15% chance to shoot at player.

Fallen: Pattern movement, moves across screen while descending. Has 15% chance to shoot at player.

Cross: Attempts to intercept player.

Homing: Moves to players last position at high speed, suicide bomber.

Boss: Has 2 “Turret” enemies. Turret enemies will act as shield while also shooting player. 15% chance. The Boss enemy will begin to move and attack when its health is less than 90 points. It will shoot wide projectiles. These projectiles will block bullets and deal damage if they hit the player. 

Boss states: Idle, attacking, defend(heal), desperate attack. 

![FSM diagram](https://user-images.githubusercontent.com/47320199/55905771-9900d200-5bca-11e9-983c-0e1f4993d96f.png)
