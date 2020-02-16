import React, { Component } from 'react';
import * as signalR from '@aspnet/signalr';

export class Counter extends Component {
    static displayName = Counter.name;

    constructor(props) {
        super(props);
        this.state = { currentCount: 0 };
        this.incrementCounter = this.incrementCounter.bind(this);
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1,
            connection = null
        });
    }

    componentDidMount() {
        //console.log("Hey, start here")
        //const mssg = window.prompt('Your name:', 'John');
        //console.log("Message: ", mssg);
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("/messagehub")
            .build();

        console.log("Connection initiated");


        this.setState({ connection });

        this.state.connection
            .start()
            .then(() => console.log('Connection started!'))
            .catch(err => console.log('Error while establishing connection :('));
    }


    render() {
        return (
            <div>
                <h1>Counter</h1>

                <p>This is a simple example of a React component.</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
            </div>
        );
    }
}
