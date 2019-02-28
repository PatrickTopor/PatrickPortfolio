//This is where the player objects will be set
//You will be responsible for this part, do this first


function Players(Name, playerAccount, turnsTaken, IsPlayerBroke){
    this.name = Name;
    this.playerAccount = playerAccount;
    this.turnsTaken = turnsTaken;
    this.IsPlayerBroke = IsPlayerBroke;
}

var player1 = new Players("Player One", 5, 0, "false");
var player2 = new Players("Lea iacta est", 5, 0, "false");
var player3 = new Players("Commodus", 5, 0, "false");