import React from 'react';

export class Property extends React.Component{

    render(){
        return(
            <div style={{ border: '4px solid yellow',display: 'flex', justifyContent: 'space-between', margin: '0', padding: '20px', backgroundImage: 'linear-gradient(to right, black, dimgray)', color: 'white'}}>
                <b>{this.props.title}</b>
                <p style={{margin: '0'}}>{this.props.propertyValue}</p>
            </div>
        );
    }
}