import React from 'react';
import { Eye } from '../eye/eye';
import { Game } from '../game/game';
import {Property} from '../property/property';

export class PlanetInfo extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            gameStarted: false,
            onQuantumMoon: false,
            myJson: []
        };
        this.toggleGame = this.toggleGame.bind(this);
    }

    toggleGame(){
        if(this.state.gameStarted){
            this.setState({gameStarted: false});     
            fetch('https://localhost:44342/Planet')
            .then(res => res.json())
            .then(res => {
                this.setState({
                    myJson: res
                });                
            });       
        } else {
            this.setState({gameStarted: true});
        }
        /*this.intervalID = setInterval(() => {
            const pos = window.addEventListener('mousemove', getMousePos);
        });*/
    }

    componentDidMount(){
        fetch('https://localhost:44342/Planet')
        .then(res => res.json())
            .then(res => {
                this.setState({
                    myJson: res
                });                
            });
    }

    render(){
        var gameStarted = '';
        console.log(this.state.myJson.imageSrc);
        if(!this.state.gameStarted){
            gameStarted = (
                <div>  
                    <button onClick={this.toggleGame} style={{position:'absolute', right: '10px' , backgroundImage: 'url(/img/EyeUniverse-black.webp)', backgroundSize: 'cover', borderRadius: '15px', width: '30px', height: '30px'}}></button>
                    <div style={{display: 'flex', justifyContent:'space-around', alignItems: 'flex-end', paddingTop: '5%'}}>
                        <div style={{width: '45%', backgroundColor: 'yellow', margin: '0', borderRadius: '1%'}}>
                            <p style={{textAlign: 'center', fontSize: '35px', margin: '0'}}>{this.state.myJson.name}</p>
                            <img src={'/img/'+this.state.myJson.imageSrc} style={{width: '98%'}}></img>
                        </div>
                        <div id='properties' style={{width: '45%', height: '', margin:'1%', borderRadius: '0px'}}>

                            <Property title='Type' propertyValue={this.state.myJson.type}/>

                            <Property title='Gravity' propertyValue={this.state.myJson.gravity}/>

                            <Property title='Inhabitants' propertyValue={this.state.myJson.inhabitants}/>

                            <Property title='Location' propertyValue={this.state.myJson.location}/>
                        </div> 
                    </div>
                    <div className='content' style={{textAlign: 'center', margin: '2% 1% 0% 1%', paddingBottom: '5%' ,borderRadius: '10px'}}>
                        
                        <p id='description' style={{fontSize: '150%', width: '75%' ,margin:'auto', borderRadius: '10px', color: 'white'}}>
                            {this.state.myJson.about}
                        </p>                                       
                    </div>
                </div>
            );

        } else if(this.state.myJson.name !== 'Quantum Moon'){
            gameStarted = <Game toggleGame={this.toggleGame}/>;
            console.log(this.state.myJson.name);
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