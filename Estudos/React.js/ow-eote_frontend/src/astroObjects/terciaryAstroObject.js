import React from 'react';

export class TerciaryAstroObject extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            relativePos: [0,0]
        };
        this.Move = this.Move.bind(this);
        this.angle = 0;
        this.distance = 0;
        this.size = 0;
    }

    Move(){
        //Increase 10 degrees
        //10 is 100% speed
        this.angle += Math.PI/180 * 3 * this.props.speedMultiplier;
        if(this.angle > 2*Math.PI){
            this.angle = 0;
        } 

        const x = this.props.relativeDistance / 2 * Math.cos(this.angle);
        const y = this.props.relativeDistance / 2 * Math.sin(this.angle);

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

        const imageSize = [this.size/2, this.size/2];

        //The relative position is calculated like that: if the parent is in the middle
        //of the screen the distance to the end of the screen is 1 (100%)
        const calcPosition = [this.props.parentPos[0] + this.state.relativePos[0] - imageSize[0],
                                this.props.parentPos[1] + this.state.relativePos[1] - imageSize[1]
                            ];

        // console.log(leftValue);
        // console.log(topValue);

        return(
            <div>
                 <img src={this.props.imgSrc} style={{width: (this.size * 100+'%'), position: 'absolute', left: (calcPosition[0] * 100+'%'), bottom: (calcPosition[1] * 100+'%')}}></img>
            </div>
        );
    }    
}