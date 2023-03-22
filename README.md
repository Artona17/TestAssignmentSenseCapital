# TestAssignmentSenseCapital
This project is Web Api implementation for tic-tac-toe game.
It provides 3 endpoints to communicate with server after launching.
1.
2.
3.
# How to launch server
# How to play
1)Use /create_game endpoint to create new game. It returns new Guid token that 2nd player should use to connect your lobby;
Example:
## Request
![image](https://user-images.githubusercontent.com/50428440/226944037-a138cb02-5c07-4b37-8640-a21f15f55453.png)
## Response
![image](https://user-images.githubusercontent.com/50428440/226944220-8cb4837a-65aa-4212-b74b-97b1c46de104.png)

You can pass field size parameter to change default settings of game board. It must be not lower than 2.
2)Use /make_next_turn endpoint to request new turn.
Example:
## Request
![image](https://user-images.githubusercontent.com/50428440/226945377-e19885e2-421a-45c7-b58a-8921ea5fa92b.png)
## Response
![image](https://user-images.githubusercontent.com/50428440/226945473-9c648ffc-9643-487c-9c14-4da842dee2e2.png)

3)Use /get_info_about_the_game to get actual information about game board and to define when it is your turn.
It would be easily to provide possibility play via session with SignalR but it is overengineering in current case.
Example:
## Request

## Response
