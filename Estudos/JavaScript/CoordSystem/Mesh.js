import Face from "./Face.js";

export default class Mesh{
    constructor(letter){
        this.faces = [];
        if(letter === "j"){
            let front = new Face();
            front.points = [
                [5, -5, 100],
                [5, -5, 0],
                [5, -25, 0],
                [5, -50, 40],
                [5, -30, 40],
                [5, -20, 20],
                [5, -20, 100]
            ];
            front.color = "blue";
            this.faces.push(front);

            let back = new Face();
            back.points= [
                [-5, -5, 100],
                [-5, -5, 0],
                [-5, -25, 0],
                [-5, -50, 40],
                [-5, -30, 40],
                [-5, -20, 20],
                [-5, -20, 100]
            ];
            back.color = "green";
            this.faces.push(back);

            let top = new Face();
            top.points= [
                [5, -5, 100],
                [-5, -5, 100],
                [-5, -20, 100],
                [5, -20, 100]
            ];
            this.faces.push(top);

            let right = new Face();
            right.points= [
                [5, -5, 100],
                [-5, -5, 100],
                [-5, -5, 0],
                [5, -5, 0]

            ];
            this.faces.push(right);

            let bot = new Face();
            bot.points= [
                [5, -5, 0],
                [-5, -5, 0],
                [-5, -25, 0],
                [5, -25, 0]
            ];
            this.faces.push(bot);

            let diagLeft = new Face();
            diagLeft.points= [
                [5, -25, 0],
                [-5, -25, 0],
                [-5, -50, 40],
                [5, -50, 40]
            ];
            this.faces.push(diagLeft);

            let topbot = new Face();
            topbot.points= [
                [5, -50, 40],
                [-5, -50, 40],
                [-5, -30, 40],
                [5, -30, 40]
            ];
            this.faces.push(topbot);

            let diagRight = new Face();
            diagRight.points= [
                [5, -30, 40],
                [-5, -30, 40],
                [-5, -20, 20],
                [5, -20, 20]
            ];
            this.faces.push(diagRight);

        } else if(letter === "s"){

            let front = new Face();
            front.points = [
                [5, 25, 100],
                [5, 50, 90],
                [5, 50, 70],
                [5, 25, 70],
                [5, 50, 30],
                [5, 50, 10],
                [5, 25, 0],
                [5, 0, 10],
                [5, 0, 30],
                [5, 25, 30],
                [5, 0, 90]
            ];
            front.color = "blue";
            this.faces.push(front);

            let back = new Face();
            back.points= [
                [-5, 25, 100],
                [-5, 50, 90],
                [-5, 50, 70],
                [-5, 25, 70],
                [-5, 50, 30],
                [-5, 50, 10],
                [-5, 25, 0],
                [-5, 0, 10],
                [-5, 0, 30],
                [-5, 25, 30],
                [-5, 0, 90]
            ];
            back.color = "green";
            this.faces.push(back);

            let topRight = new Face();
            topRight.points= [
                [5, 25, 100],
                [-5, 25, 100],
                [-5, 50, 90],
                [5, 50, 90]
            ];
            this.faces.push(topRight);

            let rightTop = new Face();
            rightTop.points= [
                [5, 50, 90],
                [-5, 50, 90],
                [-5, 50, 70],
                [5, 50, 70]

            ];
            this.faces.push(rightTop);

            let bot = new Face();
            bot.points= [
                [5, 50, 70],
                [-5, 50, 70],
                [-5, 25, 70],
                [5, 25, 70]
            ];
            this.faces.push(bot);

            let diagMidRight = new Face();
            diagMidRight.points= [
                [5, 25, 70],
                [-5, 25, 70],
                [-5, 50, 30],
                [5, 50, 30]
            ];
            this.faces.push(diagMidRight);

            let rightBot = new Face();
            rightBot.points= [
                [5, 50, 30],
                [-5, 50, 30],
                [-5, 50, 10],
                [5, 50, 10]
            ];
            this.faces.push(rightBot);

            let diagBotRight = new Face();
            diagBotRight.points= [
                [5, 50, 10],
                [-5, 50, 10],
                [-5, 25, 0],
                [5, 25, 0]
            ];
            this.faces.push(diagBotRight);

            let diagBotLeft = new Face();
            diagBotLeft.points= [
                [5, 25, 0],
                [-5, 25, 0],
                [-5, 0, 10],
                [5, 0, 10]
            ];
            this.faces.push(diagBotLeft);

            let leftBot = new Face();
            leftBot.points= [
                [5, 0, 10],
                [-5, 0, 10],
                [-5, 0, 30],
                [5, 0, 30]
            ];
            this.faces.push(leftBot);

            let top = new Face();
            top.points= [
                [5, 0, 30],
                [-5, 0, 30],
                [-5, 25, 30],
                [5, 25, 30]
            ];
            this.faces.push(top);

            let diagmidLeft = new Face();
            diagmidLeft.points= [
                [5, 25, 30],
                [-5, 25, 30],
                [-5, 0, 90],
                [5, 0, 90]
            ];
            this.faces.push(diagmidLeft);

            let final = new Face();
            final.points= [
                [5, 0, 90],
                [-5, 0, 90],
                [-5, 25, 100],
                [5, 25, 100]
            ];
            this.faces.push(final);
        }
    }
}