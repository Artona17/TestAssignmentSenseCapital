# TestAssignmentSenseCapital
This project is Web Api implementation for tic-tac-toe game.
It provides 3 endpoints to communicate with server after launching.
# How to play
## Use /create_game endpoint to create new game. It returns new Guid token that 2nd player should use to connect to your lobby;
### Request
![image](https://user-images.githubusercontent.com/50428440/226944037-a138cb02-5c07-4b37-8640-a21f15f55453.png)
### Response
![image](https://user-images.githubusercontent.com/50428440/226944220-8cb4837a-65aa-4212-b74b-97b1c46de104.png)

You can pass field size parameter to change default settings of game board. It must be not lower than 2.

## Use /make_next_turn endpoint to request new turn.
### Request
![image](https://user-images.githubusercontent.com/50428440/226948496-d4743f1a-97d4-4dc0-9caa-b6d9fb28d028.png)

## Use /get_info_about_the_game to get actual information about game board and to define when it is your turn.
It would be easy to provide opportunity to play via SignalR sessions but it is overengineering in thid case.
### Request
![image](https://user-images.githubusercontent.com/50428440/226945377-e19885e2-421a-45c7-b58a-8921ea5fa92b.png)
### Response
![image](https://user-images.githubusercontent.com/50428440/226948322-cc890bd5-a60d-4da4-9dbc-2c611832dbcf.png)
