import React from 'react';
import { Eye } from '../eye/eye';
import { Game } from '../game/game';
import {Property} from '../property/property';

export class PlanetInfo extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            gameStarted: false,
            onQuantumMoon: false
        };
        this.toggleGame = this.toggleGame.bind(this);
    }

    toggleGame(){
        if(this.state.gameStarted){
            this.setState({gameStarted: false});            
        } else {
            this.setState({gameStarted: true});
        }
        /*this.intervalID = setInterval(() => {
            const pos = window.addEventListener('mousemove', getMousePos);
        });*/
    }

    render(){

        var gameStarted = '';

        if(!this.state.gameStarted){
            gameStarted = (
                <div>
                    <button onClick={this.toggleGame} style={{position:'absolute', right: '10px' , backgroundImage: 'url(/img/EyeUniverse-black.webp)', backgroundSize: 'cover', borderRadius: '15px', width: '30px', height: '30px'}}></button>
                    <div style={{display: 'flex', justifyContent:'space-around', alignItems: 'flex-end', paddingTop: '5%'}}>
                        <div style={{width: '45%', backgroundColor: 'yellow', margin: '0', borderRadius: '1%'}}>
                            <p style={{textAlign: 'center', fontSize: '35px', margin: '0'}}>Dark Bramble</p>
                            <img src='/img/Dark_Bramble.webp' style={{width: '98%'}}></img>
                        </div>
                        <div id='properties' style={{width: '45%', height: '', margin:'1%', borderRadius: '0px'}}>

                            <Property title='Type' propertyValue='Planetary Remnant (originally ice planet)'/>

                            <Property title='Gravity' propertyValue='0g (Interior) 0.4 (Exterior)'/>

                            <Property title='Inhabitants' propertyValue='Feldspar, Anglerfish, Jellyfish (originally)'/>

                            <Property title='Location' propertyValue='5th planet'/>
                        </div> 
                    </div>
                    <div className='content' style={{textAlign: 'center', margin: '2% 1% 0% 1%', paddingBottom: '5%' ,borderRadius: '10px'}}>
                        
                        <p id='description' style={{fontSize: '150%', width: '75%' ,margin:'auto', borderRadius: '10px', color: 'white'}}>
                            Dark Bramble is a large, confusing network of twisted vines and teleportation 
                            passages, the imploded remnants of a fifth planet that has long since been infected 
                            and overrun by space-bending plant growth. It is the only planet to feature hostile 
                            wildlife in the form of Anglerfish.
                        </p>                                       
                    </div>
                </div>
            );

        } else if(!this.state.onQuantumMoon){
            gameStarted = <Game toggleGame={this.toggleGame}/>;
        } else{
            gameStarted = <Eye toggleGame={this.toggleGame}/>;
        }

        

        return(
            <div>
                {gameStarted}
            </div>
            
        );
    }
}