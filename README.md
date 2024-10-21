# WordGame
# This is simple console game to improve your typing skill

It uses Inmemory database to save results

game uses importing word dictionaries from csv format and saves words to game files at JSON separated by difficulty

this solution uses Template method to organize different console menus as one patter
also it uses Command to invoke menu actions to do same business logic.

Commented files lays at folder Patters, here would be Base Menu, which do first action setup,
and Main menu which uses MenuItems to invoke action with names at any time after creation.

Also other app can do next save result to DB, be played, you need to type as much as possible provided words correctly.