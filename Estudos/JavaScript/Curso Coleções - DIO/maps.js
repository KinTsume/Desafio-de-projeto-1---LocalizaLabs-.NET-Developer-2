//This is a study of Maps

//Return the humans
function GetHumans(map){
    let humans = [];
    for([key, value] of map){
        if(value === "Human"){
            humans.push(key);
        }
    }
    return humans;
}

//Return the monsters
function GetMonsters(map){
    let monsters = [];
    for([key, value] of map){
        if(value != "Human" && value != "Robot"){
            monsters.push(key);
        }
    }
    return monsters;
}

//Return Wes because he is useless
function GetUseless(map){
    let wes = [];
    for([key, value] of map){
        if(key === "Wes"){
            wes.push(key);
        }
    }
    return wes;
}

const users = new Map();

users.set("Wilson", "Human");
users.set("Wortox", "Imp");
users.set("Wurt", "Merm");
users.set("Willow", "Human");
users.set("Wendy", "Human");
users.set("WX-78", "Robot");
users.set("Webber", "Spider");
users.set("Wagstaff", "Human");
users.set("Wilson", "Human");
users.set("Wes", "Human");
users.set("Wormwood", "Plant");
users.set("Weeler", "Human");

console.log(GetHumans(users));
console.log(GetMonsters(users));
console.log(GetUseless(users));