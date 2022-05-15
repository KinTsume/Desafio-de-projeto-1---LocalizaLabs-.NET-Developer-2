import Drawing from "./Drawing.js";
import MathFunc from "./MathFunc.js";

//The rotation in radians in x and z, respectively
let rotation = [0, 0];

//--------------Main functions-------------------------
let start = () => {
    setInterval(() => {
        loop();
    }, 100);

    let mat = MathFunction.matrixScale(MathFunction.matrixTest);
}

let loop = () => {

    controls(10);

    Draw.clearCanvas();
    Draw.callDrawAxis();

    Draw.drawAllPoints();
    Draw.drawAllMeshes();

    Draw.correctRotation();
}

//--------------------------------------------------------
let updateDependencys = () => {
    document.getElementById("rotationV").textContent = rotation[0];
    document.getElementById("rotationH").textContent = rotation[1];

    Draw.setRotation(rotation);
}

//--------------------Control functions-------------------
let keyState = [];
let controls = (angle) => {
    
    //Arrow Up
    if(keyState[38]){
        rotation[0] += angle;
        updateDependencys();
    }

    //Arrow Down
    if(keyState[40]){
        rotation[0] -= angle;
        updateDependencys();
    }

    //Arrow Right
    if(keyState[39]){
        rotation[1] += angle;
        updateDependencys();
    }

    //Arrow Left
    if(keyState[37]){
        rotation[1] -= angle;
        updateDependencys();
    }

}

let keydownEvent = (e) => {
    keyState[e.keyCode] = true;
}

let keyupEvent = (e) => {
    keyState[e.keyCode] = false;
}

document.addEventListener("keydown", keydownEvent);
document.addEventListener("keyup", keyupEvent)

//--------------------Initialization--------------------
let canvas = document.getElementsByTagName("canvas")[0];
let ctx = canvas.getContext('2d');

let Draw = new Drawing(canvas);
let MathFunction = new MathFunc;

start();