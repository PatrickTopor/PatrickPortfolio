//This is where the game of the logic will be decided, with a separate object dedicated for the dice
//You will be responsible for this part

let turnsTaken1 = $('#turnCount');
turnsTaken1.innerHTML = 0;
let turnsTaken2 = $('#turnCount2');//turns taken by player 2
turnsTaken3.innerHTML = 0;  
let turnsTaken3 = $('#turnCount3');//turns taken by player 3
turnsTaken3.innerHTML = 0;

let playersTurn = 1;

let dice1 = = $('#image1');
let dice2 = = $('#image2');
let button = = $('#ButtonBet');

button.disabled = false;


var player1 = new Players("Player One", 5, 0, "false");
var player2 = new Players("Lea iacta est", 5, 0, "false");
var player3 = new Players("Commodus", 5, 0, "false");

function Players(Name, playerAccount, turnsTaken, IsPlayerBroke){  //This also works!!
    this.name = Name;
    this.playerAccount = playerAccount;
    this.turnsTaken = turnsTaken;
    this.IsPlayerBroke = IsPlayerBroke;
}

    let RollDice ={  //This works!
    
    dice1Number: Math.floor(Math.random() * 6) + 1,
    
    dice2Number: Math.floor(Math.random() * 6) + 1,
        
    };

    function didPlayerWin(){
      if(RollDice.dice1Number + RollDice.dice2Number == 7){
          return true;
      }  
        else if(RollDice.dice1Number + RollDice.dice2Number == 11){
            return true;
        }
        else{
            return false;
        }  
    };

let GameLogic = {
    
    main: function(){
        //First check if there are two players who are broke
        //if yes, figure out who is left and congragulate them
        if(isPlayerOneBroke && isPlayerTwoBroke == true){
            $("#status").text ("Player three won game");
            button.disabled = true;
        }
        
        else if(isPlayerTwoBroke && isPlayerThreeBroke == true){
            $("#status").text ("Player one won game");
            button.disabled = true;
        }
        
        else if(isPlayerThreeBroke && isPlayerOneBroke == true){
            $("#status").text ("Player two won game");
            button.disabled = true;
                }
        //if no, then let the game go on
        else{
            //Since the game is still on, the dice are still rolled
            dice1.src = "./images/dice-"+RollDice.dice1Number+".jpg";
            dice2.src = "./images/dice-"+RollDice.dice2Number+".jpg";
            //check whose turn it is.  
            //If it is the turn of player one, check if they are broke or not
            if(playersTurn == 1){
                //if they are broke, remind them that they cannot play and display the message
                if(isPlayerOneBroke == true){
                    $("#status").text ("Player one has lost the game!");
                    }
                    //if they are not broke, they can still play
                else{
                    //Call the function to roll the dice and see if the user won
                //if user won, add one dollar and congragulate them on the win
                if(didPlayerWin() == true){
                    $("#status").text ("Player one has won the round!");
                    $("#balance1").text(parseInt($("#balance").text()) + 1);
                    player1.playerAccount++;
                }
                //if user losses, take away one dollar and tell them that they lost
                else{
                    $("#balance").text(parseInt($("#balance").text()) - 1);
                    player1.playerAccount--;
                    if(playerAccount1 == 0){
                        isPlayerOneBroke=true
                        $("#status").text ("Player one has lost the game!");                 
                        }
                
                    else{
                    $("#status").text ("Player one has lost the round!");
                    }
                    //Also check if they are broke and make player one broke = true
                }
                player1.turnsTaken++;
            }
        //either way, the turn is passed to player 2        
        playersTurn = 2;
        }
    
        //if it is the turn of player two to play    
        else if(playersTurn == 2){
            //check if they are broke or not
            if(isPlayerTwoBroke == true){
               $("#status").text ("Player two has lost the game!"); 
                }
            //if they are not broke, let the game go on
            else{
                //Call the function to roll the dice and see if the user won
                //if user won, add one dollar and congragulate them on the win
                if(didPlayerWin() == true){
                    $("#status").text ("Player two has won the round!"); 
                    $("#balance2").text(parseInt($("#balance").text()) + 1);
                    player2.playerAccount++;
                }
            //if user losses, take away one dollar and tell them that they lost
                else{
                    player2.playerAccount--;
                    $("#balance2").text(parseInt($("#balance").text()) - 1);
                    if(playerAccount2 == 0){
                        isPlayerTwoBroke == true;
                        $("#status").text ("Player two has lost the game!");                 
                    }
                
                    else{
                        $("#status").text ("Player two has lost the round!");
                    }
                //Also check if they are broke and make player two broke = true
                }
                player2.turnsTaken++;
            }
                //either way, the turn is passed to player three
            playersTurn = 3;
        }
            //if it is the turn of player three
        else if(playersTurn == 3){
            //check if they are broke
                if(isPlayerTwoBroke == true){
                    $("#status").text ("Player three has lost the game!");
                }
                //if not, let the game go on
                else{
                //Call the function to roll the dice and see if the user won
                    //if user won, add one dollar and congragulate them on the win
                    if(didPlayerWin() == true){
                        $("#status").text ("Player three has won the round!");
                        $("#balance3").text(parseInt($("#balance").text()) + 1);
                        player3.playerAccount++;
                        }
                        //if user losses, take away one dollar and tell them that they lost
                        else{
                            player3.playerAccount--;
                            $("#balance3").text(parseInt($("#balance").text()) - 1);
                            if(playerAccount3 == 0){
                                isPlayerThreeBroke=true;
                                $("#status").text ("Player three has lost the game!");             
                            }
                
                            else{
                                $("#status").text ("Player three has lost the round!");
                            }
                            //Also check if they are broke and make player one broke = true
                        }
                        player3.turnsTaken++;
                    }
                    //either way, the turn goes back to player one
                playersTurn = 1;
            }
        } 
    }
    
}
