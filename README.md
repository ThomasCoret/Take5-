# Take5-
This project implements the card game take 5 and allows custom created players to play the game.
I created this since I was curious how much an actual strategy matters in this game.
If you have played this game you know there can be a lot of chaos and unexpected things happening.
To test this I have created two random bots, one who does everything completely random. 
And one who only plays random cards, but does not replace random rows.
I compared their performance against another player with a pretty basic strategy. 
It always plays the card that has the smallest difference to the rows in the game.
For ties it chooses the lowest card since lowest cards will cause you to have to take rows.
If there are no cards that fit on the board, it picks the highest card, hoping someone undercuts him so he doesn't have to take a row.

# Some results:
The results are all 3v3 matches over 10.000 games until a player goes over 66 penalty points 
Random vs Random Smart Row Replacer\
(This is actual output from the 'simulation' itself:)

All games over, final score (in losses):\
Random Player 1: 2998\
Random Player 2: 2893\
Random Player 3: 2952\
Random Smart Row Replace Player 4: 447\
Random Smart Row Replace Player 5: 400\
Random Smart Row Replace Player 6: 443\

The random with smart row taking/replacing loses about 1/7 the times of a completely random player

The Smallest card difference player (SCD player) vs random

All games over, final score (in losses):\
Random Player 1: 3183\
Random Player 2: 3142\
Random Player 3: 3208\
SCD Player 4: 207\
SCD Player 5: 199\
SCD Player 6: 200\

SCD loses about 1/15 the times of a random player

SCD vs smart row replace random:

All games over, final score (in losses):\
SCD Player 1: 1051\
SCD Player 2: 1049\
SCD Player 3: 1013\
Random Smart Row Replace Player 4: 2356\
Random Smart Row Replace Player 5: 2275\
Random Smart Row Replace Player 6: 2387\

SCD loses half of the time the Random Smart row replacer loses.

# Conclusion
In conclusion it looks like playing cards that fit in closely with the board looks to be a good strategy against random opponents.
There is a lot of improvement still left, for example actually looking how full the rows are, how many penalty points are in a row
and playing low cards when the rows are not filled to take the fewest penalty points on row replacing.
Feel free to to design your own player to test against these players!

P.S
This is not really intended for multiple 'human' players at the same time, since playing as a human shows your hand to the other players.
