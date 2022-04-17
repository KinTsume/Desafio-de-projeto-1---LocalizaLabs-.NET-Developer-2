import React from 'react';

export class Comet extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            relativePos: [0,0]
        };
        this.Move = this.Move.bind(this);
        this.angle = 0;
        this.distance = 0;
        this.precessionAngle = 0;   
        this.size = 0;     
        
    }

    Move(){
        this.angle += Math.PI/180 * 2 * this.props.speedMultiplier;

        //.25 is the constant that makes the precession add 45 degrees on each
        //turn
        this.precessionAngle += Math.PI/180 * .25;
        if(this.angle > Math.PI*2){
            this.angle = 0;            
        } 
        if(this.precessionAngle > 2*Math.PI){
            this.precessionAngle = 0;
        }

        const x = this.props.relativeDistance/2 * Math.cos(this.angle);
        const y = this.props.relativeDistance/2 * Math.sin(this.angle) / 2;

        this.setState({
            relativePos: [x, y] 
        });

        this.size = .05;
    }

    componentDidMount(){
        this.intervalId = setInterval(() => {
            this.Move();
        }, 50);
    }

    componentWillUnmount(){
        clearInterval(this.intervalId);
    }

    render(){

        const imageSize = [this.size / 2, this.size / 2];

        //The comet follows a ellipse so: x=r*cos(alpha)*a and y=r*cos(alpha)*b
        //in this case: a = 1 and b = 1/2
        //The precession is calculated rotating the ellipse by beta angles
        // ->> x'= x * cos(beta) + y * cos(beta + 90°)
        // ->> y'= x * sin(beta) + y * sin(beta + 90°)
        const precessionCos = Math.cos(this.precessionAngle);
        const precessionCos2 = Math.cos(this.precessionAngle + Math.PI/2);
        const precessionSin = Math.sin(this.precessionAngle);
        const precessionSin2 = Math.sin(this.precessionAngle + Math.PI/2);


        const precessionPos = [this.state.relativePos[0]*precessionCos+
                                this.state.relativePos[1]*precessionCos2,
                                this.state.relativePos[0]*precessionSin+
                                this.state.relativePos[1]*precessionSin2
                                ];
        
        //The distance the center of the ellipse is far from the sun
        const centerRadius = .2;

        //The center of the ellipse
        //the ellipse rotation axis is not on its center so it needs to be moved too 
        const center = [ centerRadius * Math.cos(this.precessionAngle + Math.PI), centerRadius * Math.sin(this.precessionAngle + Math.PI)];

        //calcPosition is the position of the top-left vertex of this image
        const calcPosition = [this.props.parentPos[0] + precessionPos[0] - imageSize[0] + center[0],
                                this.props.parentPos[1] + precessionPos[1] - imageSize[1] + center[1]
                            ];

        return (
            <div>
                <img src={this.props.imgSrc} style={{width: (this.size * 100+'%'), position: 'absolute', left: (calcPosition[0] * 100+'%'), bottom: (calcPosition[1] * 100+'%')}}></img>
            </div> 
        );
    }    
}