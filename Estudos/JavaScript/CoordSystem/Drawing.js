import Face from "./Face.js";
import Mesh from "./Mesh.js";

export default class Drawing {

    constructor(canvas){
        this.ctx = canvas.getContext("2d");
        this.width = parseInt(canvas.getAttribute("width"));
        this.height = parseInt(canvas.getAttribute("height"));

        this.rotation = [0, 0];

        this.pointsToDraw = [
            [100, 100, 100]
        ];

        this.facesToDraw = [];

        this.meshesToDraw = [
            new Mesh("j"),
            new Mesh("s")
        ];
    }

//-------------------Getters and setters------------------
    setRotation(arr){
        this.rotation = arr;
    }

//-------------------------------------------------------

    drawAllPoints(){
        this.pointsToDraw.forEach((item) => {
            let [x, y, z] = item;
            this.drawPoint(x, y, z);
        });
    }

    drawAllFaces(){
        this.facesToDraw.forEach((item) => {
            this.drawFace(item.points);
        });
    }

    drawAllMeshes(){
        this.meshesToDraw.forEach((item) => {
            this.drawMesh(item.faces);
        });
    }
    
//-----------Drawing shapes functions
    drawPoint(x, y, z) {
        let [cx, cy] = this.getCanvasCoord(x, y, z);
        this.drawScreenPoint(cx, cy);
    }

    drawScreenPoint(x, y){
        this.ctx.beginPath();
        this.ctx.arc(x, y, 5, 0, 2*Math.PI);
        this.ctx.fill();
    }

    drawFace(points, color){
        this.ctx.beginPath();
        let [fx, fy, fz] = points[0];
        let [fcx, fcy] = this.getCanvasCoord(fx, fy, fz);
        this.ctx.moveTo(fcx, fcy);

        points.forEach((item) => {
            let [x, y, z] = item;
            let [cx, cy] = this.getCanvasCoord(x, y, z);
            this.ctx.lineTo(cx, cy);
        });

        this.ctx.lineTo(fcx, fcy);
        if(color != ""){
            this.ctx.fillStyle = color;
        }
        this.ctx.stroke();
        this.ctx.fillStyle = "black";
    }

    drawMesh(faces){
        faces.forEach((item) => {
            this.drawFace(item.points, item.color);
        });
    }

//-------------Axis functions--------------------
    callDrawAxis(){

        this.drawAxis([1, 0, 0], "red");
        this.drawAxis([0, 1, 0], "green");
        this.drawAxis([0, 0, 1], "blue"); 
    
        this.ctx.strokeStyle = "black";
    
    }
    
    drawAxis(direction, color){
    
        let dir = direction.map((item) => {
            return item * 3/7 * this.width;
        });
    
        let arr = this.getCanvasCoord(dir[0], dir[1], dir[2]);
        this.ctx.beginPath();
        this.ctx.moveTo(this.width/2, this.height/2);
        this.ctx.lineTo(arr[0], arr[1]);
        this.ctx.strokeStyle = color;
        this.ctx.stroke();
    }
//------------General functions----------------
    clearCanvas(){
        this.ctx.clearRect(0, 0, this.width, this.height);
    }

    correctRotation(){
        if(this.rotation[0] < -180){
            this.rotation[0] = 180;
        } else if(this.rotation[0] > 180){
            this.rotation[0] = -180;
        }
    
        if(this.rotation[1] < -180){
            this.rotation[1] = 180;
        } else if(this.rotation[1] > 180){
            this.rotation[1] = -180;
        }
    }

    getCanvasCoord(x, y, z){
        let radianRot = {
            x: Math.PI / 180 * this.rotation[0], 
            z: Math.PI / 180 * this.rotation[1]
        };
    
        let xCoord = [Math.cos(radianRot.z), Math.sin(radianRot.z) * Math.sin(radianRot.x)];
        let yCoord =  [Math.cos(radianRot.z + Math.PI / 2), Math.sin(radianRot.z + Math.PI / 2) * Math.sin(radianRot.x)];
        let zCoord =  [0, Math.cos(radianRot.x)];
    
        let canvasRelative = [xCoord[0]*x + yCoord[0]*y, xCoord[1]*x + yCoord[1]*y + zCoord[1]*z];
    
        let canvasAbsolute = [canvasRelative[0] + this.width / 2, -canvasRelative[1] + this.height / 2]
    
        return canvasAbsolute;
    }

}