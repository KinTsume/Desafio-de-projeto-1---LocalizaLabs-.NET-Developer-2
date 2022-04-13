import React from 'react';

export class Eye extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            mousePosition: [],
            onQuantumMoon: false
        };
        this.setMousePos = this.setMousePos.bind(this);
    }

    render(){
        return(
            <div style={{width: '100vh', height: '100vh'}}>
                <button onClick={this.props.toggleGame} style={{position:'absolute', zIndex: '2' , right: '10px' , backgroundImage: 'url(/img/EyeUniverse-white.webp)', backgroundSize: 'cover', borderRadius: '15px', width: '30px', height: '30px'}}></button>
                <div style={{width: '100%', height: '100%', position: 'absolute', backgroundImage: 'radial-gradient(circle 50px at '+this.state.mousePosition[0]+'% '+this.state.mousePosition[1]+'%, transparent, black)'}}></div>
                <audio id='eye-music' autoPlay>
                    <source src='/audio/The Uncertainty Principle.mp3' type='audio/mpeg'></source>
                </audio>
            </div>
        );
    }

    componentDidMount(){
        const audio = document.getElementById('eye-music');
        audio.volume = 0.1;

        window.addEventListener('mousemove', this.setMousePos);
        
        this.intervalId = setInterval(() => {

        }, 500);
    }

    componentWillUnmount(){
        window.removeEventListener('mousemove', this.setMousePos);
        clearInterval(this.intervalId);
    }

    setMousePos(e){
        const value = [100 * e.x / window.innerWidth, 100 * e.y / window.innerHeight];
        this.setState({
            mousePosition: value
        });
    }
}