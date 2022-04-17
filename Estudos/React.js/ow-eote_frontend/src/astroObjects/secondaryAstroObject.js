import React from 'react';
import { TerciaryAstroObject } from './terciaryAstroObject';

export class SecondaryAstroObject extends React.Component{
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
        this.angle += Math.PI/180 * 2 * this.props.speedMultiplier;
        if(this.angle > 2*Math.PI){
            this.angle = 0;
        } 

        const x = this.props.relativeDistance/2 * Math.cos(this.angle);
        const y = this.props.relativeDistance/2 * Math.sin(this.angle);

        this.setState({
            relativePos: [x, y] 
        });

        this.size = (this.props.useRealSize? (this.props.sizeMultiplier * .1) : .05);
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

        //calcPosition is the position of the top-left vertex of this image
        const calcPosition = [this.props.parentPos[0] + this.state.relativePos[0] - imageSize[0],
                                this.props.parentPos[1] + this.state.relativePos[1] - imageSize[1]
                            ];
        //centerPosition is the position of the center of this image
        const centerPosition =  [this.props.parentPos[0] + this.state.relativePos[0],
                                this.props.parentPos[1] + this.state.relativePos[1]
                            ];
                            
        var moonSrc = ''
        switch(this.props.moonIndex[0]){
            case 1:
                moonSrc = '/img/PlanetIcons/AttleRock.png';
                break;
            case 2:
                moonSrc = '/img/PlanetIcons/HollowsLantern.png';
                break;
            default:
        }


        var toRender = '';
        if(this.props.moonIndex[0] != 0){
            if(this.props.moonIndex[1] != 0){
                toRender = (
                    <div>
                         <img src={this.props.imgSrc} style={{width: (this.size * 100+'%'), position: 'absolute', left: (calcPosition[0] * 100+'%'), bottom: (calcPosition[1] * 100+'%')}}></img>
                         <TerciaryAstroObject imgSrc='/img/PlanetIcons/QuantumMoon.png' relativeDistance={.15} parentPos={centerPosition} speedMultiplier={1.2}/>
                         <TerciaryAstroObject imgSrc={moonSrc} relativeDistance={.1} parentPos={centerPosition} speedMultiplier={1}/>
                    </div>
                );
            } else {
                toRender = (
                    <div>
                         <img src={this.props.imgSrc} style={{width: (this.size * 100+'%'), position: 'absolute', left: (calcPosition[0] * 100+'%'), bottom: (calcPosition[1] * 100+'%')}}></img>
                         <TerciaryAstroObject imgSrc={moonSrc} relativeDistance={.1} parentPos={centerPosition} speedMultiplier={1}/>
                    </div>
                );
            }

        } else if(this.props.moonIndex[1] != 0){
            toRender = (
                <div>
                     <img src={this.props.imgSrc} style={{width: (this.size * 100+'%'), position: 'absolute', left: (calcPosition[0] * 100+'%'), bottom: (calcPosition[1] * 100+'%')}}></img>
                     <TerciaryAstroObject imgSrc='/img/PlanetIcons/QuantumMoon.png' relativeDistance={.1} parentPos={centerPosition} speedMultiplier={2}/>
                </div>
            );
        } else {
            toRender = (
                <div>
                     <img src={this.props.imgSrc} style={{width: (this.size * 100+'%'), position: 'absolute', left: (calcPosition[0] * 100+'%'), bottom: (calcPosition[1] * 100+'%')}}></img>
                </div> 
            );
        }

        return toRender;
    }    
}