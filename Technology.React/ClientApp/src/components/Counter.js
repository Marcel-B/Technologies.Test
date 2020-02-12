import React, { Component } from 'react';
import * as signalR from '@aspnet/signalr';

export class Counter extends Component {
    static displayName = Counter.name;
    static connection;

    constructor(props) {
        super(props);
        this.state = { currentCount: 0 };
        this.incrementCounter = this.incrementCounter.bind(this);
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }

    componentDidMount() {
        const mssg = window.prompt('Your name:', 'John');
        console.log("Message: ", mssg);
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/messagehub")
            .build();

        this.connection.on("ReceiveMessage", (username, message) => {

            console.log(`Hey ho, ${username} - ${message}`);
            this.setState({
                currentCount: 42
            });
        });
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
