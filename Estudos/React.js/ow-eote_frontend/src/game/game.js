import React from 'react';
import { PrimaryAstroObject } from '../astroObjects/primaryAstroObject';
import { Eye } from '../eye/eye';

export class Game extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            onQuantumMoon: false
        };
    }

    render(){

        var container = '';
        container = ( 
            <div style={{width: '100%', height: '100vh', margin: '0'}}> 
                <button onClick={this.props.toggleGame} style={{position:'absolute', right: '10px' , backgroundImage: 'url(/img/EyeUniverse-white.webp)', backgroundSize: 'cover', borderRadius: '15px', width: '30px', height: '30px', zIndex: '2'}}></button>
                <audio id='game-music' autoPlay>
                    <source src='/audio/Outer Wilds.mp3' type='audio/mpeg'></source>
                </audio> 
 
                <PrimaryAstroObject imgSrc='/img/Sun.png' pos={[.5, .5]} orbitParentId='none'/>

            </div>
        );

        return container;
    }

    componentDidMount(){
        const audio = document.getElementById('game-music');
        audio.volume = 0.1;
    }
}