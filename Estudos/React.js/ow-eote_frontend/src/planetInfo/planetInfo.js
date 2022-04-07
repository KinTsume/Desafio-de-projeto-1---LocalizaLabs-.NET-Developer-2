import React from 'react';
import {Property} from '../property/property';

export class PlanetInfo extends React.Component{
    render(){
        return(
            <div>
                <div style={{display: 'flex', justifyContent:'space-around', alignItems: 'flex-end'}}>
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
                <div className='content' style={{textAlign: 'center', margin: '2% 1% 10% 1%', borderRadius: '10px'}}>
                    
                    <p id='description' style={{fontSize: '150%', width: '75%' ,margin:'auto', borderRadius: '10px', color: 'white'}}>
                        Dark Bramble is a large, confusing network of twisted vines and teleportation 
                        passages, the imploded remnants of a fifth planet that has long since been infected 
                        and overrun by space-bending plant growth. It is the only planet to feature hostile 
                        wildlife in the form of Anglerfish.
                    </p>                                       
                </div>
                <button style={{backgroundImage: 'linear-gradient(to bottom right, black, lightblue)', color: 'white', fontSize: '35px', borderRadius: '10px', width: '40%', padding: '2%'}}>Random Planet</button>
            </div>
            
        );
    }
}