import React from 'react';
import { Comet } from './comet';
import { SecondaryAstroObject } from './secondaryAstroObject';

export class PrimaryAstroObject extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            realSizeView: false,
            quantumMoonPos: 0
        };
        this.toggleRealSizeView = this.toggleRealSizeView.bind(this);
    }

    componentDidMount(){
        this.setState({
            quantumMoonPos: Math.floor(Math.random() * 6)
        });
    }

    toggleRealSizeView(){
        const setValue = !this.state.realSizeView;
        this.setState({
            realSizeView: setValue
        });
    }

    render(){

        // const imageCenter = [.1 / 2, .1 / 2];
        // const position = [window.innerWidth * (this.props.pos[0] - imageCenter[0]), window.innerHeight * (this.props.pos[1] - imageCenter[1])];
        // console.log(position);
        const quantumMoonParent = [0, 0, 0, 0, 0, 0];
        quantumMoonParent[this.state.quantumMoonPos] = 1;

        const imageSize = [.1 / 2, .1 / 2];
        const position = [this.props.pos[0] - imageSize[0], this.props.pos[1] - imageSize[1]];

        const screenSize = [window.innerWidth, window.innerHeight];
        if(screenSize[1] < screenSize[0]){
            screenSize[0] = screenSize[1];
        } else if(screenSize[1] > screenSize[0]){
            screenSize[1] = screenSize[0];
        }

        return(
            <div style={{width: (screenSize[0] + 'px'), height: (screenSize[1] + 'px'), position: 'relative', margin: 'auto'}}>
                <button onClick={this.toggleRealSizeView}>Toggle planet real size view (don't count moons or The Interloper (comet))</button>
                <img src={this.props.imgSrc} style={{position: 'absolute', left: (position[0] * 100 +'%'), top: (position[1] * 100 + '%') ,justifySelf: 'center', width: '10%'}}></img>
                <SecondaryAstroObject moonIndex={[0, quantumMoonParent[0]]} imgSrc='/img/HourglassTwins.png' parentPos={this.props.pos} relativeDistance={0.18} speedMultiplier={1} useRealSize={this.state.realSizeView} sizeMultiplier={.176}/>
                <SecondaryAstroObject moonIndex={[1, quantumMoonParent[1]]} imgSrc='/img/TimberHearth.png' parentPos={this.props.pos} relativeDistance={0.33} speedMultiplier={.72} useRealSize={this.state.realSizeView} sizeMultiplier={.138}/>
                <SecondaryAstroObject moonIndex={[2, quantumMoonParent[2]]} imgSrc='/img/BrittleHollow.png' parentPos={this.props.pos} relativeDistance={0.45} speedMultiplier={.61} useRealSize={this.state.realSizeView} sizeMultiplier={.3}/>
                <SecondaryAstroObject moonIndex={[0, quantumMoonParent[3]]} imgSrc='/img/GiantsDeep.png' parentPos={this.props.pos} relativeDistance={0.63} speedMultiplier={.52} useRealSize={this.state.realSizeView} sizeMultiplier={1}/>
                <SecondaryAstroObject moonIndex={[0, quantumMoonParent[4]]} imgSrc='/img/DarkBramble.png' parentPos={this.props.pos} relativeDistance={0.75} speedMultiplier={.47} useRealSize={this.state.realSizeView} sizeMultiplier={.8}/>
                <Comet imgSrc='/img/TheInterloper.png' parentPos={this.props.pos} relativeDistance={0.5} speedMultiplier={1} useRealSize={this.state.realSizeView} sizeMultiplier={1}/>
            </div> 
        );
    }

}