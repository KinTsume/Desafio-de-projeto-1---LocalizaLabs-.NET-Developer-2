import React from 'react';
import { PlanetInfo } from '../planetInfo/planetInfo';

export class Start extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            language: this.props.language, 
            firstAccess: this.props.firstAccess
        };
        this.setLanguage = this.setLanguage.bind(this);
    }

    setLanguage(lang){
        this.setState({
            language: lang, 
            firstAccess: false
        });
    }

    render(){

        var content = <div></div>;
        console.log(this.state.firstAccess);
        if(this.state.firstAccess){
            content = (
            <div>
                <button onClick={() => this.setLanguage('english')}> English </button>
                <button onClick={() => this.setLanguage('portugues')}> Portugues </button>
            </div>
            );
        } else {
            content = (
                <div>
                    <PlanetInfo language={this.state.language}/>
                </div>
                );
        }

        return(
            <div>
                {content}
            </div>
        );
    }
}